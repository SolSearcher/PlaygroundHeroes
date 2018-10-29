using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHealth : EntityHealth {

    public bool TakeDamage(float amount)
    {
        health.CurrentVal -= amount;

        // Death Check
        if (health.CurrentVal <= 0)
        {
            return true; //killed em
        }
        return false;
    }
}
