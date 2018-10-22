using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisions : MonoBehaviour {

    public float m_lifetime = 1;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, m_lifetime);  //kills the arrow after an amount of time
    }

    //Collision check and damage
    private void OnTriggerEnter(Collider other) {
        //print(other);  DEBUG
        if (other.gameObject.GetComponent<EntityHealth>()!=null) //if they have no health destroy them >.<
        {
            if (other.gameObject.GetComponent<EntityHealth>().TakeDamage(20)){
                Destroy(other.gameObject);

            }
        }
    }
}
