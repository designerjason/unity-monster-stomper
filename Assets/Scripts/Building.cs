using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int health = 100;
    public GameObject person;
    public GameObject personExit;
    public int peopleCount;
    public bool peopleOut = false;
    public int curHealth;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("_GameManager").GetComponent<GameManager>();
        curHealth = health;
        StartCoroutine("SpawnPeople"); 
    }

    // building take damage
    public void Damage(int damageAmount)
    {
        curHealth = curHealth - damageAmount;
        
        if(curHealth <= 0) {
            Destroy();
        }
    }

    // building destroyed
    public void Destroy() 
    {
        gameObject.SetActive(false);
        gameManager.buildingCount = GameObject.FindGameObjectsWithTag("Building").Length;
        gameManager.BuildingCount(gameManager.buildingCount);
    }

    // spawn escaping people
    IEnumerator SpawnPeople()
    {
        while(true) {
            if(peopleOut) {
                if(peopleCount == 0) {
                    yield return null;
                } else {
                    // instantiate a person
                    GameObject tempPerson = Instantiate(person, personExit.transform.position, transform.rotation) as GameObject;
                    peopleCount--;
                }
                // randomise when they exit building
                yield return new WaitForSeconds(Random.Range(1.5f, 3.5f));
            } else {
                yield return null;
            }
        }
    }
}
