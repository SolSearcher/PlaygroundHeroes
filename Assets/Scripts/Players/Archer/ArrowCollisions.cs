using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisions : MonoBehaviour {

    public float m_lifetime = 1;

    // Use this for initialization
    void Start () {
    }

    //Collision check and damage
    private void OnTriggerEnter(Collider other) {
        //print(other);  DEBUG
        
        if(other.gameObject.GetComponent<KnightStats>() != null)
        {
            if (other.gameObject.GetComponent<KnightStats>().health.CurrentVal > 0)
            {
                other.gameObject.GetComponent<KnightStats>().health.CurrentVal -= 10;
            }
        }

        if (other.gameObject.GetComponent<KnightStats>() != null)
        {
            if (other.gameObject.GetComponent<EnemyStats>().health.CurrentVal > 0)
            {
                other.gameObject.GetComponent<EnemyStats>().health.CurrentVal -= 10;
            }
        }
    }
    
    public void fire()
    {
        Destroy(gameObject, m_lifetime);  //kills the arrow after an amount of time

    }
}
