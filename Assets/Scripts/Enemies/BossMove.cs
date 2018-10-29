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
    public float m_waitTime = 1f;

    private float currWaitTime;
    private bool isWaiting;
    private Vector3 playerLocation;

    // Use this for initialization
    void Start () {
        //start walk
        m_Animator = GetComponent<Animator>();
        isAttacking = false;
        isWaiting = false;
        currWaitTime = 0f;
        playerLocation = transform.position;

        //gets players
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        chooseTarget();

        if (isWaiting)
            currWaitTime += Time.deltaTime;

        if (currWaitTime > m_waitTime)
            isWaiting = false;

        if (!isAttacking) { 
            if(!(distTo(target) < m_attackRange))
            {
                move();
                m_Animator.SetBool("Moving", true);
            }
            else if (!isWaiting)
            {
                transform.LookAt(target.transform.position);
                isAttacking = true;
                m_Animator.SetBool("Moving", false);
                m_Animator.SetBool("Attack1Trigger", true);
            }
        }

        /*Vector3 targetPos = target.transform.position;
        targetPos.y = transform.position.y;
        Debug.Log("target: " + targetPos + "\ncurrent: " + playerLocation);
        playerLocation = Vector3.Lerp(playerLocation, targetPos, .1f);
        Debug.Log("newCurrent: " + playerLocation);
        transform.LookAt(playerLocation);*/
    }


    //move towards the player
    private void move() {
        transform.LookAt(target.transform.position);
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
        isWaiting = true;
        currWaitTime = 0f;
        hammerCollider.SetActive(false);
        //SwordCollidor.SetActive(false);
    }

}
