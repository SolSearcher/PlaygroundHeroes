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

            //Debug.Log("entered");

            if(other.gameObject.tag == "Enemies")
            {
                print("HITTING ENEMY");
                if (other.gameObject.GetComponent<EntityHealth>() != null)
                {
                    if (other.gameObject.GetComponent<EntityHealth>().TakeDamage(20))
                    {
                        Destroy(other.gameObject);
                    }
                }
            }
            if (other.gameObject.tag == "Player")
            {
                print("HITTING PLAYER");
                if (other.gameObject.GetComponent<EntityHealth>() != null)
                {
                    if (other.gameObject.GetComponent<EntityHealth>().TakeDamage(20))
                    {
                        Destroy(other.gameObject);
                    }
                }
            }

        }
    }
}
