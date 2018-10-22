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
    protected float dodgeTimeDefault;
    protected float currDodgeTime;
    
    protected void Start()
    {
        health = 100f;
        stamina = 100f;
        dodgeTimeDefault = 0.66f;
        currDodgeTime = 0f;
        inputVector = new Vector3(0, 0, 0);
        dodgeLocation = new Vector3(0, 0, 0);
        rb = GetComponent<Rigidbody>();
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
        else
            Move();

        stamina = Mathf.Clamp(stamina + 30f * Time.deltaTime, -30f, 100f);
    }

    protected void CalculateInputVector()
    {
        Vector3 camRotation = Camera.transform.eulerAngles; //Get camera rotation

        //Start with forward vector
        Vector3 camForward = new Vector3(0, 0, 1);
        camForward = Quaternion.Euler(0, camRotation.y, 0) * camForward; //Rotate it by camera's y (yaw) rotation, this gets camera forward vector

        Vector3 camRight = Quaternion.Euler(0, 90, 0) * camForward; //rotate THAT by 90 degrees to get right vector

        camRight *= Input.GetAxis("Horizontal" + playerNum); //get input
        camForward *= Input.GetAxis("Vertical" + playerNum);

        inputVector = (camRight + camForward) * Time.deltaTime * speed;
    }

    protected void Move()
    {
        Vector3 newInput = inputVector.normalized;
        if (inputVector.magnitude > .01f)
        {
            //rb.MovePosition((transform.position + newInput * Time.deltaTime * speed)); //move rigidbody
            transform.LookAt(transform.position + inputVector);
            transform.Translate(inputVector, Space.World);
        }
    }


    protected void DodgeMover()
    {
        currDodgeTime += Time.deltaTime;
        if (currDodgeTime < dodgeTimeDefault)
        {
            //rb.MovePosition(Vector3.Lerp(transform.position, dodgeLocation, 12f * Time.deltaTime));
            //Debug.Log("DodgeLocation: " + dodgeLocation + "\ntransform.position: " + transform.position + "\nsub: " + (dodgeLocation - transform.position));
            transform.Translate((dodgeLocation - transform.position) * 12f * Time.deltaTime, Space.World);
            //rb.AddForce(inputVector.normalized * (dodgeTimeDefault - currDodgeTime));
        }
        else
        {
            currDodgeTime = 0f;
            isDodging = false;
        }
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
