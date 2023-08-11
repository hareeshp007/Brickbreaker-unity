using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    [SerializeField]
    private bool GamePlay=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameWon();
    }
    void GameWon()
    {
        if (transform.childCount <= 0 && GamePlay)
        {
            Debug.Log("Game won!");
            GamePlay = false;
        }
    }
}
