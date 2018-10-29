using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightStats : EntityHealth {


    //Energy is different for players than enemies so it's all here
    [SerializeField]
    public Stat energy;

    private void Awake()
    {
        health.Initialize();
        energy.Initialize();
    }
}
