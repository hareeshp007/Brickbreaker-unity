using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    [SerializeField]
    private int BricksNo;
    public Vector3 startPosition = Vector3.zero;
    public GameObject Brickprefab; // The prefab of the game object you want to arrange
    public int rows = 5;
    public int columns = 5;
    public float spacing = 1.0f;
    private void Start()
    {
        BricksNo= transform.childCount;
        PlayerPrefs.SetInt("NumberOfBricks", BricksNo);
    }
    private void CreateBriks()
    {
        rows = PlayerPrefs.GetInt("Rows");
        columns = PlayerPrefs.GetInt("Cols");
        spacing = PlayerPrefs.GetFloat("Spacing");
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 position = startPosition+ new Vector3(col * spacing, row * spacing,0); // Calculate position
                Instantiate(Brickprefab, position, Quaternion.identity); // Instantiate the prefab
                PlayerPrefs.SetInt("NumberOfBricks", PlayerPrefs.GetInt("NumberOfBricks") + 1);
            }
        }
    }
}
