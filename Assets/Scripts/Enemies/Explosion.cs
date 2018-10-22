using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float m_lifetime = 1;
    public bool alreadyHit = false;

    protected void Start()
    {
        Destroy(gameObject, m_lifetime);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<EntityHealth>().TakeDamage(10)) //if they have no health destroy them >.<
        {
            Destroy(other.gameObject);
        }


    }

}
