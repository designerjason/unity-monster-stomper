using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int buildingCount;
    public GameObject EndScreen;
    public TextMeshProUGUI EndScreenText;

    // Start is called before the first frame update
    void Start()
    {
        buildingCount = GameObject.FindGameObjectsWithTag("Building").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(buildingCount == 0) {
            GameOver("You Win!!");
        }
    }

    public void GameOver( string screenText)
    {
        EndScreen.SetActive(true);
        EndScreenText.text = screenText;
        Time.timeScale = 0;
    }
}
