using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public float speed = 15;
    public int health = 100;
    public int curHealth;
    public float horizontalInput;
    public float verticalInput;
    public GameManager gameManager;
    protected Vector3 lookDir;    

    void Start() {
        curHealth = health;
        animator = GameObject.Find("/Player/Monster").GetComponent<Animator>();
    }

    void Update()
    {
        movePlayer();
    }

    // player movement controller
    void movePlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(verticalInput != 0 || horizontalInput !=0) {
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }

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

    // direction player is in world
    void positionPlayer(Vector3 dir)
    {
        transform.Translate(dir * Time.deltaTime * speed, Space.World);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 40);
        lookDir = dir;
    }

    // take damage
    public void Damage(int damageAmount)
    {
        curHealth = curHealth - damageAmount;
        gameManager.playerHealth.text = curHealth.ToString();
        if(curHealth <= 0) {
            animator.SetBool("isDead", true);
        }
    }
}
