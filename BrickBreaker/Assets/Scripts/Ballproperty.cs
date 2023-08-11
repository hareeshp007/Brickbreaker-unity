
using System;
using UnityEngine;

public class Ballproperty : MonoBehaviour
{
    public BallController controller;

    public float destroyDelay = 10f; // Time delay before destroying
    private float timer; // Timer to track the elapsed time

    private void Start()
    {
        timer = 0f; // Initialize the timer
    }

    private void Update()
    {
        timer += Time.deltaTime; // Increment the timer

        if (timer >= destroyDelay)
        {
            Destroy(gameObject); // Destroy the GameObject if the delay is reached
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            controller.checkBalls();
            //ballcontroller.checkballs();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Brick"))
        {
            timer = 0f;
        }
    }
    

    

}