using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    bool triggerStay = false;
    GameObject currentTarget;
    public GameManager gameManager;
    public PlayerController playerController;

    void Start() {
        animator = GameObject.Find("/Player/Monster").GetComponent<Animator>();
    }

    private void Update() {

        // space is attack
        if(Input.GetKeyDown(KeyCode.Space)) {

            animator.SetBool("isAttacking", true);

            // check if we're hitting a building
            if(triggerStay && currentTarget != null && currentTarget.tag == "Building") {
                currentTarget.GetComponent<Building>().Damage(10);
                currentTarget.GetComponent<Building>().peopleOut = true;
            } 
        }

        // this kills enemy if we touch (trample) them, and it gives us health
        if(triggerStay) {
            // check if we're hitting an enemy
            if(currentTarget.tag == "Enemy") {
                Destroy(currentTarget);
                triggerStay = false;
                currentTarget = null;

                // add to health if not full
                if(playerController.curHealth < 100) {
                    playerController.Damage(-10);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        triggerStay = true;
        currentTarget = other.gameObject;
    }

    void OnTriggerStay(Collider other)
    {
        triggerStay = true;
        currentTarget = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        triggerStay = false;
        currentTarget = null;
    }
}
