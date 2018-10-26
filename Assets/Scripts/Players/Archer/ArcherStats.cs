using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherStats : MonoBehaviour
{

    [SerializeField]
    public Stat health;
    [SerializeField]
    public Stat energy;

    private void Awake()
    {
        health.Initialize();
        energy.Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
