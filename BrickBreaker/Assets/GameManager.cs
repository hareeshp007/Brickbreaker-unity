using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public GameObject InGameUI;
    public GameObject GameWonUI;
    public TextMeshProUGUI Chances;
    public BallController ballController;

    [SerializeField]
    private bool isPaused;
    [SerializeField]
    private bool isGameWon;
    [SerializeField]
    private bool isGameOver;
    private int row, col;
    private float space;

    public string MainMenuScene;
    public int TotalLevels;
    [SerializeField]
    private string Level1 = "level1";
    [SerializeField]
    private string Level2 = "level2";
    [SerializeField]
    private string Level3 = "level3";
    // Start is called before the first frame update
    void Start()
    {   
        //LevelDetails();
        Initializationfunction();
    }

    private void Initializationfunction()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        InGameUI?.SetActive(true);
        GameWonUI?.SetActive(false);
        isGameOver = false;
        isGameWon = false;
        //PlayerPrefs.SetInt("NoOfChances", 1);
    }

    

    // Update is called once per frame
    private void Update()
    {
        
        if (!isGameOver ||!isGameWon)
        {
            //UpdateChances();
            chechGameOver();
        }
        
        checkPaused();
    }

    private void checkPaused()
    {
        if (isPaused)
        {
            ballController.enabled = false;
           // ballController.gameObject.SetActive(false);
        }
        else
        {
            ballController.enabled = true;
            //ballController.gameObject.SetActive(true);
        }
    }

    private void chechGameOver()
    {
        if(PlayerPrefs.GetInt("NumberOfBricks") <= 0 &&!isGameWon)
        {
            isGameWon = true;
            GameWon();
        }
        else if (PlayerPrefs.GetInt("NumberOfBricks") != 0 && PlayerPrefs.GetInt("NoOfChances") <= 0 && PlayerPrefs.GetInt("BallsonScene")<=0&&!isGameOver)
        {
            //Debug.Log(PlayerPrefs.GetInt("NoOfChances"));
            isGameOver = true;
            GameOver();
        }
        //throw new NotImplementedException();
    }

    private void GameWon()
    {
        Debug.Log("GameWon");
        InGameUI.SetActive(false );
        GameWonUI.SetActive(true );
        isPaused = true;
        isGameWon=true;
        LevelManager.Instance.MarkCurrentLevelCompleted();
    }

    private void UpdateChances()
    {
        Chances.text=PlayerPrefs.GetInt("NoOfChances").ToString();
    }

    public void GameOver()
    {
        Debug.Log("GameOver!!");
        GameOverMenu.SetActive(true);
        InGameUI?.SetActive(false);
        isPaused = true;
    }
    public void PauseMenuEnable()
    {
        Time.timeScale = 0;
        PauseMenu?.SetActive(true);
        InGameUI?.SetActive(false);
        isPaused = true;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
        PauseMenu?.SetActive(false);
        InGameUI?.SetActive(true);
        isPaused = false;
    }
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        int curr=SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("currScene",curr);
        SceneManager.LoadScene(MainMenuScene);
    }
    public void NextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex+1 <= TotalLevels)
        {
            SceneManager.LoadScene(sceneIndex+1);
        }
        else
        {
            SceneManager.LoadScene(MainMenuScene);
        }
        
    }
    
}
