using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 20;
    string[] targets = {"Building", "Player", "Bounds"};

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // move bullet
    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    // what happens when bullet hits something
    void OnTriggerEnter(Collider other)
    {
        // destroy bullet if it hits anything
        if(targets.Contains(other.gameObject.tag) && this.gameObject != null) {
            // TODO: this causes error if it hits player attack box
            Destroy(this.gameObject);
        }

        // player interaction
        if(other.gameObject.tag == "Player") {
            //other.gameObject.GetComponent<PlayerController>().Damage(5);
        }
    }
}
