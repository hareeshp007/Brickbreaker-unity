using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxRotationAngle = 45f;
    public GameObject ball;
    public float launchForce=10;
    public Transform shotpoint;
    
    //public List<GameObject> Ballobjects = new List<GameObject>();

    [SerializeField]
    private int balls=3;
    [SerializeField]
    private int count = 1;
    [SerializeField]
    private bool shootable=true;
    [SerializeField]
    private float delayBetweenInstantiations = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        shootable = true;
        
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButton(0)) {
            Direction();
        }
        if (Input.GetMouseButtonUp(0) && shootable)
        {  
            StartCoroutine(ShootBalls());    
        }
        
        
    }
    private void FixedUpdate()
    {
        if (!shootable)
        {
            checkBalls();
        }
        

    }
    /* public void checkballs()
     {   if(Ballobjects.Count > 0) {
             for (int i = Ballobjects.Count - 1; i >= 0; i--)
             {
                 if (Ballobjects[i] == null)
                 {
                     Debug.Log("GameObject at index " + i + " has been destroyed.");
                     Ballobjects.RemoveAt(i);
                 }
             }
         }

         else { Changeshootable(); }
         //else { Changeshootable(); }
     }*/
    
    public int Getnumberofballs()
    {
        return balls;
    }
    public void Changeshootable()
    {
        shootable = !shootable;
    }
    void Direction()
    {
        Vector2 bowpos=transform.position;
        Vector2 mousepos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction=mousepos - bowpos;

        float rotationAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rotationAngle = Mathf.Clamp(rotationAngle, -maxRotationAngle, maxRotationAngle);

        transform.rotation = Quaternion.Euler(0f, 0f, -rotationAngle);
        //Debug.Log(rotationAngle);
    }
    public IEnumerator ShootBalls()
    {
        count = balls;
        Debug.Log(count);
        for (int i=0;i< count; i++) {
            GameObject newBall = Instantiate(ball, shotpoint.position, shotpoint.rotation);
            newBall.GetComponent<Rigidbody2D>().velocity = transform.up * launchForce;
            //Ballobjects.Add(newBall);
            PlayerPrefs.SetInt("BallsonScene", PlayerPrefs.GetInt("BallsonScene") + 1);
            yield return new WaitForSeconds(delayBetweenInstantiations);
        }
        count = balls;
        Debug.Log(count);
        Changeshootable();
        //create a number of gameobjects of the ball
        //give it a velocity for each ball in the direction of mouse click
    }
    //shoot a number of balls in the direction of mouse click
    //outline the path of the balls
    void PathOutLine()
    {

    }
    //when the shooted ball all have been destroyed reset the number of balls and reset the ball pos
    public void checkBalls()
    {
        if (PlayerPrefs.GetInt("BallsonScene") == 0)
        {
            Changeshootable();
        }
        
    }
}
