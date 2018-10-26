using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    [SerializeField]
    public Stat health;


    private void Awake()
    {
        health.Initialize();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
