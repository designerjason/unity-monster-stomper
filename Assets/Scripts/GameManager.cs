using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int buildingCount;
    public GameObject endScreen;
    public GameObject enemy;
    public TextMeshProUGUI endScreenText;
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI buildingCountText;
    public List<Transform> spawnList = new List<Transform>();
    public List<Transform> boundsList = new List<Transform>();

    void Start()
    {
        buildingCount = GameObject.FindGameObjectsWithTag("Building").Length;
        BuildingCount(buildingCount);
        StartCoroutine("SpawnEnemy");
    }

    void Update()
    {
        if(buildingCount == 0) {
            GameOver("You Win!!");
        }
    }

    // happens when the game ends, dsplay a message
    public void GameOver( string screenText)
    {
        endScreen.SetActive(true);
        endScreenText.text = screenText;
        Time.timeScale = 0;
    }

    // enemy spawner
    IEnumerator SpawnEnemy()
    {
        while(true) {
            int index = Random.Range(0, spawnList.Count);
            GameObject tempEnemy = Instantiate(enemy, spawnList[index].position, transform.rotation);
            yield return new WaitForSeconds(4);
        }
    }

    // display for number of buildings not destroyed
    public void BuildingCount(int count) {
        buildingCountText.text = "Buildings: " + count.ToString();
    }
}
