using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherStats : EntityHealth
{

    [SerializeField]
    public Stat energy;

    private void Awake()
    {
        health.Initialize();
        energy.Initialize();
    }
}
