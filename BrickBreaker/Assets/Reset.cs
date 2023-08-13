using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    private Button LevelButton;
    // Start is called before the first frame update
    void Start()
    {
        LevelButton = GetComponent<Button>();
        LevelButton.onClick.AddListener(ResetLevels);
    }

    private void ResetLevels()
    {
        LevelManager.Instance.LevelReset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
