using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int health = 100;
    public int curHealth;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("_GameManager").GetComponent<GameManager>();
        curHealth = health;
    }

    public void Damage(int damageAmount)
    {
        curHealth = curHealth - damageAmount;
        
        if(curHealth <= 0) {
            Destroy();
        }
    }

    public void Destroy() 
    {
        gameObject.SetActive(false);
        gameManager.buildingCount = GameObject.FindGameObjectsWithTag("Building").Length;
    }
}
