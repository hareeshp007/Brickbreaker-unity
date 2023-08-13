using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxRotationAngle = 45f;
    public GameObject ball;
    public float launchForce=10;
    public Transform shotpoint;
    public TextMeshProUGUI Chances;
    public TextMeshProUGUI BallsUI;

    public GameManager gameManager;
    //public List<GameObject> Ballobjects = new List<GameObject>();

    [SerializeField]
    private int balls=3;
    [SerializeField]
    private int count = 1;
    [SerializeField]
    private bool shootable=true;
    [SerializeField]
    private float delayBetweenInstantiations = 0.05f;
    [SerializeField]
    private int NoofChances=7;
    private void Awake()
    {
        PlayerPrefs.SetInt("NoOfChances", NoofChances);
    }
    // Start is called before the first frame update
    void Start()
    {
        shootable = true;
        PlayerPrefs.SetInt("BallsonScene", 0);
        balls= Random.Range(30, 50);
        transform.rotation = Quaternion.identity;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(shootable) { 
        UpdateChances();
        if(Input.GetMouseButton(0)) {
            Direction();
        }
        if (Input.GetMouseButtonUp(0)&&NoofChances>0)
        {  
            StartCoroutine(ShootBalls());
            PlayerPrefs.SetInt("NoOfChances", --NoofChances);
            }
        }

    }
    private void UpdateChances()
    {
        Chances.text = PlayerPrefs.GetInt("NoOfChances").ToString();
        BallsUI.text=balls.ToString();
    }
    private void FixedUpdate()
    {
        if (!shootable)
        {
            checkBalls();
        }
        

    }
    
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
        
        Changeshootable();
        count = balls;

        for (int i=0;i< count; i++) {
            GameObject newBall = Instantiate(ball, shotpoint.position, shotpoint.rotation);
            newBall.GetComponent<Rigidbody2D>().velocity = transform.up * launchForce;
            //Ballobjects.Add(newBall);
            PlayerPrefs.SetInt("BallsonScene", PlayerPrefs.GetInt("BallsonScene") + 1);
            yield return new WaitForSeconds(delayBetweenInstantiations);
        }
        count = balls;

        
        //create a number of gameobjects of the ball
        //give it a velocity for each ball in the direction of mouse click
    }
    //when the shooted ball all have been destroyed reset the number of balls and reset the ball pos
    public void checkBalls()
    {
        //Debug.Log(PlayerPrefs.GetInt("BallsonScene"));
        if (PlayerPrefs.GetInt("BallsonScene") == 0)
        {
            Changeshootable();
        }
        
    }
}
