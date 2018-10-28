using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField]
    private BarScript bar;

    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentVal;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }
        set
        {
            //prevents values from going over max value and less than 0
            this.currentVal = Mathf.Clamp(value,-30f,MaxVal);
            //sets the value for each bar to current value

            if(bar != null) // if the player has a bar update it. enemies won't
            {
                bar.Value = currentVal;
                
            }
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }

        set
        {
            this.maxVal = value;
            bar.MaxValue = maxVal;
        }
    }

    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }
}
