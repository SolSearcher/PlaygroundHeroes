using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : PlayerController
{
    public GameObject SwordCollidor;
    public bool isAttacking;
    private Animator animator;
    private Collider swordCollider;

	// Use this for initialization
	protected void Start ()
    {
        base.Start();
        animator = GetComponent<Animator>();
        isAttacking = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CalculateInputVector();
        if (Input.GetButtonDown("Dodge" + playerNum))
            Dodge();

        if (isDodging)
        {
            DodgeMover();
        }
        else if(!isAttacking)
            Move();

        if (inputVector.magnitude > .03f)
            animator.SetBool("Moving", true);
        else
            animator.SetBool("Moving", false);

        if(Input.GetButtonDown("Fire1") && GetComponent<KnightStats>().energy.CurrentVal > 40)
            Attack();

        GetComponent<KnightStats>().energy.CurrentVal = Mathf.Clamp(GetComponent<KnightStats>().energy.CurrentVal + 20f * Time.deltaTime, -30f, 100f);
    }

    void Attack ()
    {
        animator.SetTrigger("Attack1Trigger");
    }

    void AttackStart()
    {
        isAttacking = true;
        SwordCollidor.SetActive(true);
        GetComponent<KnightStats>().energy.CurrentVal -= 40;
    }

    void AttackEnd()
    {
        isAttacking = false;
        SwordCollidor.SetActive(false);
    }
}
