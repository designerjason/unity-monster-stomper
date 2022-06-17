using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    public IEnumerator shootPlayer;
    private GameObject player;
    private float distance;
    NavMeshAgent agent;
    private Vector3 directionOfTarget;
    private bool challenged;

    void Start() {
        // instantiate items
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("ShootPlayer"); 
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < 15f) {
            challenged = true;
            transform.LookAt(player.transform.position);
            
        } else {
            challenged = false;
        }

        // make enemy follow path to player
        agent.SetDestination(player.transform.position);
    }

    // shoot the player, when close enough to them
    IEnumerator ShootPlayer()
    {
        // enemies have limited rounds in a clip
        int rounds = 5;
        while(true) {
            // challenged true if we are within a certain distance, so shoot at the player
            if(challenged) {
                Vector3 tempBulletPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

                // wait to reload
                if(rounds == 0) {
                    yield return new WaitForSeconds(2);
                    rounds = 5;
                } else {
                    GameObject tempBullet = Instantiate(bullet, tempBulletPos, transform.rotation) as GameObject;
                    rounds--;
                }
                // pause between shots
                yield return new WaitForSeconds(0.5f);
            } else {
                // we don't want to do anything or shoot if the playre is too far away
                yield return null;
            }
        }
    }
}
