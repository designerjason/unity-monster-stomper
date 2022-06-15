using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    private GameObject player;
    private float distance;
    public IEnumerator shootPlayer;
    NavMeshAgent agent;
    private Vector3 directionOfTarget;
    private bool challenged;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("ShootPlayer"); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.transform.position);
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
        while(true) {
            if(challenged) {
                GameObject tempBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation) as GameObject;
                yield return new WaitForSeconds(1);
            } else {
                yield return null;
            }
        }
    }
}
