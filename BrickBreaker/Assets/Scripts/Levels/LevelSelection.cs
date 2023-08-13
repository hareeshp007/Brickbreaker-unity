using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelection : MonoBehaviour
{
    private Button LevelButton;
    public string LevelName;
    public int Levelnum;
    void Start()
    {
        LevelButton = GetComponent<Button>();
        LevelButton.onClick.AddListener(LevelSelect);
    }

    private void LevelSelect()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.locked:
                Debug.Log(Levelnum + " This Level is Locked:");
                break;
            case LevelStatus.unlocked:
                Debug.Log(Levelnum + " This Level is Unlocked:");
                LevelManager.Instance.LoadAnyLevel(Levelnum);
                break;
            case LevelStatus.completed:
                Debug.Log(Levelnum + " This Level is Completed:");
                LevelManager.Instance.LoadAnyLevel(Levelnum);
                break;
        }

    }

}