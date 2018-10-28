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
        //damaged = true;
        //Debug.Log(currentHealth);
        //currentHealth -= amount;
        health.CurrentVal -= amount;
        print("CurVal = " +health.CurrentVal);
        //print("ouch, hp = " + currentHealth);
        // Death Check
        if (health.CurrentVal <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
            return true; //killed em
        }
        return false;
    }
}