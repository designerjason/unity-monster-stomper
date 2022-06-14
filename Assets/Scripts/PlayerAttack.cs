using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool triggerStay = false;
    GameObject currentTarget;
    PlayerController playerController;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && triggerStay) {
            if(currentTarget.tag == "Building") {
                currentTarget.GetComponent<Building>().Damage(20);
            }
            if(currentTarget.tag == "Enemy") {
                Destroy(currentTarget);
                triggerStay = false;
                currentTarget = null;
                if(playerController.health< 100) {
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
