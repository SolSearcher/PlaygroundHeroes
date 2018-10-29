using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EntityHealth : MonoBehaviour
{
    [SerializeField]
    public Stat health;

    private void Awake()
    { 
        health.Initialize();
    }

    void Update()
    {
        //print("CURVAL " + health.CurrentVal);
    }


    public bool TakeDamage(float amount)
    {
        health.CurrentVal -= amount;

        // Death Check
        if (health.CurrentVal <= 0)
        {
            //print(gameObject.tag);
            if(gameObject.tag == "Player")
            {
                SceneManager.LoadScene("DeathScreen");
            }
            return true; //killed em
        }
        return false;
    }
}