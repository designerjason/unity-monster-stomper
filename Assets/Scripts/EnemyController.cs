using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform Target;
    public GameObject Bullet;
    private float distance;
    public IEnumerator shootPlayer;
    NavMeshAgent agent;
    private Vector3 directionOfTarget;
    private bool challenged;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("ShootPlayer"); 
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Target.transform.position);
        if(distance < 15f) {
            challenged = true;
            transform.LookAt(Target);
            
        } else {
            challenged = false;
        }

        agent.SetDestination(Target.position);
    }

    IEnumerator ShootPlayer()
    {
        while(true) {
            if(challenged) {
                GameObject tempBullet = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation) as GameObject;
                yield return new WaitForSeconds(1);
            } else {
                yield return null;
            }
        }
    }
}
