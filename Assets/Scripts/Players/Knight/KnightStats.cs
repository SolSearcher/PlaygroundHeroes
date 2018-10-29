using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnightStats : EntityHealth {


    //Energy is different for players than enemies so it's all here
    [SerializeField]
    public Stat energy;

    private void Awake()
    {
        health.Initialize();
        energy.Initialize();
    }

    public bool TakeDamage(float amount)
    {
        health.CurrentVal -= amount;

        // Death Check
        if (health.CurrentVal <= 0)
        {
            print("PLaYERDEATH");
            SceneManager.LoadScene("DeathScreen");
            return true; //killed em
        }
        return false;
    }


}
