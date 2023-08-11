
using TMPro;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public TextMeshProUGUI CounterText;
    public int BrickHealth;
    // Start is called before the first frame update
    void Start()
    {
        BrickHealth=Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
    }
    void checkHealth()
    {
        if (BrickHealth == 0)
        {
            Destroy(this.gameObject);
        }
        else if(BrickHealth > 0) { 
            CounterText.text = BrickHealth.ToString();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ballproperty>()!=null)
        {
            BrickHealth--;  
        }
    }
}
