using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BoomCamera Camera;
    public int playerNum;
    public float speed = 5f;
    public float _moveSpeedModifier = 500f;

    protected Vector3 inputVector;
    protected Rigidbody rb;
    protected Vector3 dodgeLocation;
    protected bool isDodging;
    protected float health;
    protected float stamina;
    
    protected void Start()
    {
        health = 100f;
        stamina = 100f;
        inputVector = new Vector3(0, 0, 0);
        dodgeLocation = new Vector3(0, 0, 0);
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Dodge" + playerNum))
            Dodge();

        if (isDodging)
        {
            DodgeMover();
        }

        if (!isDodging)
            Move();

        stamina = Mathf.Clamp(stamina + 30f * Time.deltaTime, -30f, 100f);
    }

    /*  Original Move() I had problems with it so I'm trying to rewrite it now - Reed
    protected void Move()
    {
        Vector3 camRotation = Camera.transform.eulerAngles; //Get camera rotation

        //Start with forward vector
        Vector3 camForward = new Vector3(0, 0, 1);
        camForward = Quaternion.Euler(0, camRotation.y, 0) * camForward; //Rotate it by camera's y (yaw) rotation, this gets camera forward vector

        Vector3 camRight = Quaternion.Euler(0, 90, 0) * camForward; //rotate THAT by 90 degrees to get right vector

        camRight *= Input.GetAxis("Horizontal" + playerNum) * Time.deltaTime * speed; //get input
        camForward *= Input.GetAxis("Vertical" + playerNum) * Time.deltaTime * speed;

        inputVector = camRight + camForward;

        if (inputVector.magnitude > .01f)
        {
            rb.MovePosition(transform.position + inputVector*_moveSpeedModifier); //move rigidbody

            transform.LookAt(transform.position + inputVector);
        }
    }
    */


    //        transform.Translate(Vector3.forward * Time.deltaTime);


    protected void Move()
    {
        Vector3 camRotation = Camera.transform.eulerAngles; //Get camera rotation

        //Start with forward vector
        Vector3 camForward = new Vector3(0, 0, 1);
        camForward = Quaternion.Euler(0, camRotation.y, 0) * camForward; //Rotate it by camera's y (yaw) rotation, this gets camera forward vector

        Vector3 camRight = Quaternion.Euler(0, 90, 0) * camForward; //rotate THAT by 90 degrees to get right vector

        camRight *= Input.GetAxis("Horizontal" + playerNum) * Time.deltaTime * speed; //get input
        camForward *= Input.GetAxis("Vertical" + playerNum) * Time.deltaTime * speed;

        inputVector = camRight + camForward;

        if (inputVector.magnitude > .05f)
        {
            //rb.MovePosition(transform.position + inputVector * _moveSpeedModifier); //move rigidbody
            transform.Translate(Vector3.forward * Time.deltaTime *8);

            transform.LookAt(transform.position + inputVector);
        }
    }


    protected void DodgeMover()
    {
        if (Vector3.Distance(transform.position, dodgeLocation) > 0.1)
            rb.MovePosition(Vector3.Lerp(transform.position, dodgeLocation, 12f * Time.deltaTime));
        else
            isDodging = false;
    }

    protected void Dodge()
    {
        if (stamina > 0)
        {
            stamina -= 22.5f;
            if (inputVector.magnitude > .03f)
            {
                dodgeLocation = transform.position + inputVector.normalized * 4f;
                isDodging = true;
            }
            else
            {
                dodgeLocation = transform.position + transform.forward * -4f;
                isDodging = true;
            }
        }
    }

    /*
     * Removes val health from the health pool (clamping between 0 and 100
     * input float val: amount of health to be removed
    */
    protected void RemoveHealth(float val)
    {
        health = Mathf.Clamp(health - val, 0f, 100f);

        if(health <= 0f)
        {
            Debug.Log("Dead!");
            health = 5f;
        }
    }
}
