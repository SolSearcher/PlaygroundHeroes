using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public GameObject _player0;
    public GameObject _player1;
    Animator m_Animator;

    //private GameObject target;

    // Use this for initialization
    void Start()
    {
        //chooseTarget();
        m_Animator = GetComponent<Animator>();
        m_Animator.Play("walk");

    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 x = _player0.GetComponent<Transform>().position;   how to grab pos component
        //target = chooseTarget();


        transform.LookAt(chooseTarget().GetComponent<Transform>().position);
        transform.Translate(Vector3.forward * Time.deltaTime);

    }

    //Walks at the closer of the two players
    private GameObject chooseTarget()
    {
        if (distTo(_player0) < distTo(_player1))
        {
            return _player0;
        }
        else
        {
            return _player1;
        }

    }

    //Dist to other game object
    private float distTo(GameObject player)
    {
        return Vector3.Distance(player.GetComponent<Transform>().position, this.GetComponent<Transform>().position);
    }
}
