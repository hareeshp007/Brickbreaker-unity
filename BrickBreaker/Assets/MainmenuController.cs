using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuController : MonoBehaviour
{
    public GameObject LevelsUI;
    public GameObject MainMenuUI;

    private void Start()
    {
        MainMenuUI.SetActive(true);
        LevelsUI.SetActive(false);
    }
    public void Play()
    {
        int curr = PlayerPrefs.GetInt("currScene");
        if(curr == 0)
        {
            curr++;
        }
        SceneManager.LoadScene(curr);
    }
    public void Exit()
    {
        Debug.Log("Exit Application");
        Application.Quit();
    }
    public void Levels()
    {
        MainMenuUI.SetActive(false);
        LevelsUI.SetActive(true);
    }
    public void ChooseLevel(int Level)
    {
        SceneManager.LoadScene(Level);
    }
}
