using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHammer : MonoBehaviour {

    public BossMove LEEROYJENKINS;

    private void OnTriggerEnter(Collider other)
    {
        if (LEEROYJENKINS.isAttacking)
        {
            //LEEROYJENKINS.isAttacking = false;
            //this.gameObject.SetActive(false);

            if (other.gameObject.tag == "Player")
            {
                PlayerController controller = other.gameObject.GetComponent<PlayerController>();

                if (controller.isBlockingCheck())
                {
                    other.gameObject.GetComponent<ArcherStats>().blockDamage(30f);
                }
                else if (other.gameObject.GetComponent<EntityHealth>() != null && !controller.isInvuln())
                {
                    print("HITTING PLAYER");
                    if (other.gameObject.GetComponent<EntityHealth>().TakeDamage(LEEROYJENKINS.m_attackDamage))
                    {
                        Destroy(other.gameObject);
                    }
                }
            }

        }
    }




}
