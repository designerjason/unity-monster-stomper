using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Civilian : MonoBehaviour
{
    NavMeshAgent agent;
    GameManager gameManager;
    public List<Transform> boundList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        // instantiate gamemaneger
        gameManager = GameObject.Find("_GameManager").GetComponent<GameManager>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // go to nearest boundary
        agent.SetDestination(GetNearestBoundary(gameManager.boundsList).transform.position);
    }

    // find the nearest boundary so we can move towards it
    Transform GetNearestBoundary(List<Transform> bounds)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform potentialTarget in bounds)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        
        return bestTarget;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bounds") {
            Destroy(gameObject);
        }
    }
}
