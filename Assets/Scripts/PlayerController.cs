using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15;
    public int health = 100;
    public int curHealth;
    public float horizontalInput;
    public float verticalInput;
    protected Vector3 lookDir;
    public GameManager gameManager;

    void Start() {
        curHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (verticalInput > 0)
        {
            positionPlayer(Vector3.forward);
        }
        if (verticalInput < 0)
        {
            positionPlayer(Vector3.back);
        }
        if (horizontalInput > 0)
        {
            positionPlayer(Vector3.right);
        }
        if (horizontalInput < 0)
        {
            positionPlayer(Vector3.left);
        }
    }

    void positionPlayer(Vector3 dir)
    {
        transform.Translate(dir * Time.deltaTime * speed, Space.World);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 40);
        lookDir = dir;
    }

    public void Damage(int damageAmount)
    {
        curHealth = curHealth - damageAmount;
        Debug.Log("Player Health:" + curHealth);
        if(curHealth <= 0) {
            gameManager.GameOver("You Died!!");
        }
    }
}
