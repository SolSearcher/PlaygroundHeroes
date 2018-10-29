using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    //Players to target
    //public GameObject _player0;
    //public GameObject _player1;
    public GameObject m_explosion;

    //Attack tweak variables
    public float m_attackRange = 1;

    //Fuse vars
    public float m_fuseTimer = 1200;
    public float m_fuseTickAmount = 5;
    public float m_fuseThreshold = 10;
    public float m_lifetime = 1;

    private float currentFuseTime;
    public Color tickColor = Color.red;


    Animator m_Animator;
    Renderer renderer;
    public Material mat;


    bool primed = false;
    bool attacking = false;


    //private GameObject target;

    // Use this for initialization
    void Start()
    {
        //Variable setup
        currentFuseTime = m_fuseTimer;
        primed = false;

        renderer = GetComponentInChildren<Renderer>();
        mat = renderer.material;

       // GetComponentInChildren<Renderer>();
        //GetComponent<>

        //Start walk animation
        m_Animator = GetComponent<Animator>();
        m_Animator.Play("walk");

    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            if (fuseTime())
            {
                //Boom

                //print("Boom");
                Instantiate(m_explosion, transform.position, Quaternion.identity);
                Destroy(gameObject, m_lifetime);

                //attacking = false;
            }
            //print("already Attacking");
        }
        else
        {
            if (inAttackRange()) // Checks range then starts logic
            {
               // print("attacking start!!");
                attacking = true;

                // To Do!
                // Need to have an attack function that will return something when the animation is played out
            }
            else // If you're not close enough toi attack, walk at the nearest player
            {
                walkAtPlayer();
            }
        }
        

    }

    private bool fuseTime()
    {
        //if we've counted down 
        if(m_fuseTimer <= 0)  //if fuse has run down
        {
            //print("BOOMMMMM");
            mat.SetColor("_EmissionColor", tickColor); // Tick on
            return true;
        }
        
        //Boom
        if (currentFuseTime <= 0) // if time between ticks has run down
        {
            if (primed) //if already red
            {
                mat.SetColor("_EmissionColor", Color.black);  //Tick off
                primed = false;
            }
            else
            {
                mat.SetColor("_EmissionColor", tickColor); // Tick on
                primed = true;
            }

            //Lower the time for the next tick and restart
            m_fuseTimer -= m_fuseTickAmount;
            currentFuseTime = m_fuseTimer;
        }

        //Iterates the time
        currentFuseTime--;
        return false;
    }


    // checks if it's close to a player then starts the attack logic
    private bool inAttackRange() {
        if(distTo(chooseTarget()) < m_attackRange)
        {
            return true;
        }
        return false;
    }

    //moves and roates towards player
    private void walkAtPlayer()
    {
        transform.LookAt(chooseTarget().GetComponent<Transform>().position);
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    //Walks at the closer of the two players
    private GameObject chooseTarget()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Player");
        GameObject closestPlayer = objs[0];

        

        if (distTo(objs[0]) < distTo(objs[1]))
        {
            return objs[0];
        }
        else
        {
            return objs[1];
        }
    }

    //Dist to other game object
    private float distTo(GameObject player)
    {
        return Vector3.Distance(player.GetComponent<Transform>().position, this.GetComponent<Transform>().position);
    }
}
