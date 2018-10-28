using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : PlayerController
{
    public GameObject SwordCollidor;
    public bool isAttacking;
    public bool isBlocking;
    public GameObject Shield;
    private Animator animator;
    private Collider swordCollider;

	// Use this for initialization
	protected void Start ()
    {
        base.Start();
        animator = GetComponent<Animator>();
        isAttacking = false;
        isBlocking = false;
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

        if(isBlocking)
        {
            Shield.SetActive(true);
        }
        else
        {
            Shield.SetActive(false);
        }

        if (isDodging)
        {
            DodgeMover();
        }
        else if (!isAttacking)
        {
            if (isBlocking)
                inputVector *= 0.5f;
            Move();
        }

        if (inputVector.magnitude > .03f)
            animator.SetBool("Moving", true);
        else
            animator.SetBool("Moving", false);

        if(Input.GetButtonDown("Fire1") && GetComponent<ArcherStats>().energy.CurrentVal > 40)
            Attack();

        GetComponent<ArcherStats>().energy.CurrentVal = Mathf.Clamp(GetComponent<ArcherStats>().energy.CurrentVal + 20f * Time.deltaTime, -30f, 100f);
    }

    void Attack ()
    {
        animator.SetTrigger("Attack1Trigger");
    }

    void AttackStart()
    {
        isAttacking = true;
        SwordCollidor.SetActive(true);
        GetComponent<ArcherStats>().energy.CurrentVal -= 40;
    }

    void AttackEnd()
    {
        isAttacking = false;
        SwordCollidor.SetActive(false);
    }
}
