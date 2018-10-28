using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : PlayerController
{
    public GameObject SwordCollidor;
    public bool isAttacking;
    public GameObject Shield;
    private Animator animator;
    private Collider swordCollider;

    private bool attackingAnim;

	// Use this for initialization
	protected void Start ()
    {
        base.Start();
        animator = GetComponent<Animator>();
        isAttacking = false;
        attackingAnim = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CalculateInputVector();
        if (Input.GetButtonDown("Dodge" + playerNum))
            Dodge();

        if (Input.GetButton("Block"))
            isBlocking = true;
        else
            isBlocking = false;
        
        if (isDodging)
        {
            DodgeMover();
        }
        else if (!attackingAnim)
        {
            if (isBlocking)
                inputVector *= 0.5f;
            Move();

            if (inputVector.magnitude > .03f)
                animator.SetBool("Moving", true);
            else
                animator.SetBool("Moving", false);

            if (Input.GetButtonDown("Fire1") && GetComponent<ArcherStats>().energy.CurrentVal > 15f)
                Attack();
        }
        else
        {
            if (Camera.isLocked)
            {
                Vector3 lookAtPos = Camera.testEnemy.transform.position;
                lookAtPos.y = transform.position.y;

                transform.LookAt(lookAtPos);
            }
            transform.Translate(transform.forward * Time.deltaTime, Space.World);
        }

        if (isBlocking)
        {
            Shield.SetActive(true);
            if (Camera.isLocked)
            {
                Vector3 lookAtPos = Camera.testEnemy.transform.position;
                lookAtPos.y = transform.position.y;

                transform.LookAt(lookAtPos);
            }
        }
        else
        {
            Shield.SetActive(false);
        }

        if (!isBlocking)
            GetComponent<ArcherStats>().energy.CurrentVal = Mathf.Clamp(GetComponent<ArcherStats>().energy.CurrentVal + 20f * Time.deltaTime, -30f, 100f);
        else
            GetComponent<ArcherStats>().energy.CurrentVal = Mathf.Clamp(GetComponent<ArcherStats>().energy.CurrentVal + 5f * Time.deltaTime, -30f, 100f);
    }

    void Attack ()
    {
        animator.SetTrigger("Attack1Trigger");
        attackingAnim = true;
    }

    void AttackStart()
    {
        isAttacking = true;
        SwordCollidor.SetActive(true);
        GetComponent<ArcherStats>().energy.CurrentVal -= 40f;
    }

    void AttackEnd()
    {
        isAttacking = false;
        SwordCollidor.SetActive(false);
    }

    void AnimationOver()
    {
        attackingAnim = false;
    }
}
