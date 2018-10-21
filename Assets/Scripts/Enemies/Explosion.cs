using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    

    private void OnTriggerEnter(Collider other)
    {

        //this.gameObject.SetActive(false);
        //Debug.Log("entered");
        print("Boom");
            if (other.gameObject.GetComponent<EntityHealth>().TakeDamage(10)) //if they have no health destroy them >.<
            {
                Destroy(other.gameObject);
            }

        Destroy(this.gameObject);
    }
    
}
