using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;


    void Start()
    {
        currentHealth = startingHealth;
    }

    // void Update () 
    // {
    // 	// if(damaged)
    // 	// {
    // 	// 	damageImage.color = flashColor;
    // 	// }
    // 	// else
    // 	// {
    // 	// 	damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
    // 	// }
    // 	// damaged = false;

    // }

    public void TakeDamage(int amount)
    {
        //damaged = true;
        Debug.Log(currentHealth);
        currentHealth -= amount;

        // Death Check
        if (currentHealth < 0)
        {
            print("#ded");
        }
    }
}
