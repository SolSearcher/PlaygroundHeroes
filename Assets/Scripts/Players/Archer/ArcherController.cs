using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : PlayerController
{
    public GameObject Bow;
    public GameObject m_arrowPrefab;
    private GameObject Arrow;

    private Vector3 bowDownPos;
    private Quaternion bowDownRot;
    private Vector3 bowFirePos;
    private Quaternion bowFireRot;
    private bool firing;
    private float arrowSpeed;
	// Use this for initialization
	protected new void Start ()
    {
        base.Start();
        bowDownPos = new Vector3(-0.2f, -0.13f, 0.78f);
        bowDownRot = Quaternion.Euler(166f, 97f, -20f);
        bowFirePos = new Vector3(-0.15f, 0.33f, 0.95f);
        bowFireRot = Quaternion.Euler(100f, 175f, 90f);
        arrowSpeed = 10f;

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
            Arrow.transform.position = transform.position;
            GetComponent<ArcherStats>().energy.CurrentVal = Mathf.Clamp(GetComponent<ArcherStats>().energy.CurrentVal + 5f * Time.deltaTime, -30f, 100f);

            arrowSpeed = Mathf.Clamp(arrowSpeed + (0.75f*90f) * Time.deltaTime, 0f, 100f);
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
            GetComponent<ArcherStats>().energy.CurrentVal = Mathf.Clamp(GetComponent<ArcherStats>().energy.CurrentVal + 20f * Time.deltaTime, -30f, 100f);
        }
    }

    void GetInput()
    {
        CalculateInputVector();
        if (Input.GetButtonDown("Fire" + playerNum) && GetComponent<ArcherStats>().energy.CurrentVal > 10f)
        {
            arrowSpeed = 10f;
            firing = true;
            Camera.playerControl = true;
            Bow.transform.localPosition = bowFirePos;
            Bow.transform.localRotation = bowFireRot;

            Vector3 newRotation = transform.rotation.eulerAngles;
            Vector3 newPosition = transform.position + transform.forward;
            Arrow = Instantiate(m_arrowPrefab, newPosition, Quaternion.Euler(90, newRotation.y, newRotation.z)) as GameObject;
        }
        if (firing && Input.GetButtonUp("Fire" + playerNum))
        {
            firing = false;
            Camera.playerControl = false;
            GetComponent<ArcherStats>().energy.CurrentVal -= 30f;
            Bow.transform.localPosition = bowDownPos;
            Bow.transform.localRotation = bowDownRot;

            if(Arrow != null)
            {
                Arrow.GetComponent<ArrowCollisions>().fire();
                Arrow.GetComponent<Rigidbody>().velocity = arrowSpeed * transform.forward;
            }
            
        }
    }
}
