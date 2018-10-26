using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightStats : MonoBehaviour {

    [SerializeField]
    private Stat health;
    [SerializeField]
    private Stat energy;

    private void Awake()
    {
        health.Initialize();
        energy.Initialize();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
