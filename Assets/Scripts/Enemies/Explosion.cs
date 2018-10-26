using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float m_lifetime = 1;

    protected void Start()
    {
        Destroy(gameObject, m_lifetime);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<ArcherStats>().health.CurrentVal > 0)
        {
            other.gameObject.GetComponent<ArcherStats>().health.CurrentVal -= 10;
        }


        if (other.gameObject.GetComponent<KnightStats>().health.CurrentVal > 0)
        {
            other.gameObject.GetComponent<KnightStats>().health.CurrentVal -= 10;
        }

    }
}
