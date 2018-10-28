using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHammer : MonoBehaviour {

    public BossMove LEEROYJENKINS;

    private void OnTriggerEnter(Collider other)
    {
        if (LEEROYJENKINS.isAttacking)
        {
            LEEROYJENKINS.isAttacking = false;
            this.gameObject.SetActive(false);

            if (other.gameObject.tag == "Player")
            {
                print("HITTING PLAYER");
                if (other.gameObject.GetComponent<EntityHealth>() != null)
                {
                    if (other.gameObject.GetComponent<EntityHealth>().TakeDamage(LEEROYJENKINS.m_attackDamage))
                    {
                        Destroy(other.gameObject);
                    }
                }
            }

        }
    }




}
