using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    GameManager gameManager;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("/_GameManager").GetComponent<GameManager>();
        animator = GameObject.Find("/Player/Monster").GetComponent<Animator>();
    }

    void isDead()
    {
        Debug.Log("I am dead!");
        gameManager.GameOver("You Died!!");
    }

    void noAttack()
    {
        Debug.Log("attack stopped");
        animator.SetBool("isAttacking", false);
    }
}
