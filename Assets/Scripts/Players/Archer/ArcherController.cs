using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : PlayerController
{
    public GameObject Bow;
    public GameObject Arrow;

    private Vector3 bowDownPos;
    private Quaternion bowDownRot;
    private Vector3 bowFirePos;
    private Quaternion bowFireRot;
    private bool firing;
	// Use this for initialization
	protected new void Start ()
    {
        base.Start();
        bowDownPos = new Vector3(-0.2f, -0.13f, 0.78f);
        bowDownRot = Quaternion.Euler(166f, 97f, -20f);
        bowFirePos = new Vector3(-0.15f, 0.33f, 0.95f);
        bowFireRot = Quaternion.Euler(100f, 175f, 90f);

        firing = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetInput();
        if (firing)
        {
            Vector3 camRotation = Camera.transform.eulerAngles;
            float rotationNeeded = camRotation.y - transform.eulerAngles.y;
            transform.Rotate(new Vector3(0, rotationNeeded, 0));

            Vector3 newRotation = transform.rotation.eulerAngles;
            newRotation.x = 90;

            Arrow.transform.rotation = Quaternion.Euler(newRotation);
            Arrow.transform.position = transform.position + transform.forward;
        }
        else
        {
            if (Input.GetButtonDown("Dodge" + playerNum))
                Dodge();

            if (!firing)
            {
                if (isDodging)
                {
                    DodgeMover();
                }
                else
                    Move();
            }
        }
        stamina = Mathf.Clamp(stamina + 30f * Time.deltaTime, -30f, 100f);
	}

    void GetInput()
    {
        CalculateInputVector();
        if (Input.GetButtonDown("Fire" + playerNum))
        {
            firing = true;
            Camera.playerControl = true;
            Bow.transform.localPosition = bowFirePos;
            Bow.transform.localRotation = bowFireRot;

            Vector3 newRotation = transform.rotation.eulerAngles;
            Vector3 newPosition = transform.position + transform.forward;
            Arrow = Instantiate(Arrow, newPosition, Quaternion.Euler(90, newRotation.y, newRotation.z)) as GameObject;
        }
        if (Input.GetButtonUp("Fire" + playerNum))
        {
            firing = false;
            Camera.playerControl = false;
            Bow.transform.localPosition = bowDownPos;
            Bow.transform.localRotation = bowDownRot;

            Arrow.GetComponent<Rigidbody>().velocity = 50f * transform.forward;
        }
    }
}
