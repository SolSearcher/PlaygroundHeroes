﻿using UnityEngine;
using System.Collections;


public class EnemyHealth : MonoBehaviour
{
    //public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.
    public Stat health;
    GameObject player;                          // Reference to the player GameObject.
    ArcherStats Archerhealth;
    KnightStats Knighthealth;                      // Reference to the player's health.
    //EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    //float timer;                                // Timer for counting up to the next attack.


    private void Awake ()
    {
        // Setting up the references.
        health.Initialize();
        //enemyHealth = GetComponent<EnemyHealth>();
    }


    void OnTriggerEnter (Collider other)
    {
        // If the entering collider is the player...
        if(other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        // If the exiting collider is the player...
        if(other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        //timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        //if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        //{
            // ... attack.
    	//Debug.Log(player.
    	if(playerInRange){
            Attack();
    	}
        //}
    }


    void Attack()
    {
        
    }
}