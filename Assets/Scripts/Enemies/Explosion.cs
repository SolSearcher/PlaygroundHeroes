using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float m_lifetime = 1;
    public float m_damage = 1f;
    protected void Start()
    {
        Destroy(gameObject, m_lifetime);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            print("HITTING PLAYER");
            if (other.gameObject.GetComponent<EntityHealth>() != null)
            {
                if (other.gameObject.GetComponent<EntityHealth>().TakeDamage(m_damage))
                {
                    Destroy(other.gameObject);
                }
            }
        }

    }
}
