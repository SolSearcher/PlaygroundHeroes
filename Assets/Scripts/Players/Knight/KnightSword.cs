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
        }
    }
}
