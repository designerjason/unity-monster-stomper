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
    public List<Transform> spawnList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        buildingCount = GameObject.FindGameObjectsWithTag("Building").Length;
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
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
}
