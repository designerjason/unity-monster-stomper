using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 20;
    string[] targets = {"Building", "Player", "Bounds"};
    GameObject currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(targets.Contains(other.gameObject.tag)) {
            Destroy(gameObject);
        };

        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerController>().Damage(10);
        }
    }
}
