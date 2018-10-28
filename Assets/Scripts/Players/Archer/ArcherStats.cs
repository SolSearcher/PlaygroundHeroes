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

    public void blockDamage(float val)
    {
        energy.CurrentVal = Mathf.Clamp(energy.CurrentVal - val, 0f, 100f);
    }
}
