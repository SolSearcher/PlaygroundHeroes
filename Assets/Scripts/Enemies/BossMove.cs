using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour {

    //Var Declaration
    Animator m_Animator;
    public bool isAttacking;

    GameObject[] players;
    private GameObject target;
    public GameObject hammerCollider;

    public float m_attackRange = 10f;
    public float m_attackDamage = 30f;

    // Use this for initialization
    void Start () {
        //start walk
        m_Animator = GetComponent<Animator>();
        isAttacking = false;

        //gets players
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        chooseTarget();

        if (!isAttacking) { 
            if(distTo(target) < m_attackRange)
            {
                isAttacking = true;
                m_Animator.SetBool("Moving", false);
                m_Animator.SetBool("Attack1Trigger", true);
            }
            else
            {
                move();
                m_Animator.SetBool("Moving", true);
            }
        }
    }


    //move towards the player
    private void move() {
        transform.LookAt(target.GetComponent<Transform>().position);
    } 
    

    //Chooses the closest player
    private void chooseTarget()
    {
        if (distTo(players[0]) < distTo(players[1]))
        {
            target = players[0];
        }
        else
        {
            target = players[1];
        }
    }

    //Dist to other game object
    private float distTo(GameObject player)
    {
        return Vector3.Distance(player.GetComponent<Transform>().position, this.GetComponent<Transform>().position);
    }


    void StartAttack()
    {
        isAttacking = true;
        hammerCollider.SetActive(true);
        //SwordCollidor.SetActive(true);
    }

    void EndAttack()
    {
        isAttacking = false;
        hammerCollider.SetActive(true);
        //SwordCollidor.SetActive(false);
    }

}
