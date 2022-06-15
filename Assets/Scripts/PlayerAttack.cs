using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool triggerStay = false;
    GameObject currentTarget;
    public GameManager gameManager;
    public PlayerController playerController;

    private void Update() {

        // space is attack
        if(Input.GetKeyDown(KeyCode.Space) && triggerStay) {

            // check if we're hitting a building
            if(currentTarget != null && currentTarget.tag == "Building") {
                currentTarget.GetComponent<Building>().Damage(20);
            }

            // check if we're hitting an enemy
            if(currentTarget.tag == "Enemy") {
                if(currentTarget != null && currentTarget.tag == "Enemy") {
                    Destroy(currentTarget);
                }
                triggerStay = false;
                currentTarget = null;

                // add to health if not full
                if(playerController.health < 100) {
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

    void OnTriggerExit(Collider other)
    {
        triggerStay = false;
        currentTarget = null;
    }
}
