using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSword : MonoBehaviour
{
    public KnightController Player;

    /*private void OnTriggerStay(Collider other)
    {
        if (Player.isAttacking)
        {
            Player.isAttacking = false;
            Debug.Log("entered");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (Player.isAttacking)
        {
            Player.isAttacking = false;
            this.gameObject.SetActive(false);
            Debug.Log("entered");

            if( other.gameObject.GetComponent<EntityHealth>().TakeDamage(10)) //if they have no health destroy them >.<
            {
                Destroy(other.gameObject);
            }
            
            //we need to call a function inside the other entity to recieve damage and die
        }
    }
}
