using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    private float fillAmount;

    [SerializeField]
    private float lerpSpeed;
    [SerializeField]
    private Image HP_Bar;

    [SerializeField]
    private Text valueText;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            //changes text on bars
            string[] tmp = valueText.text.Split(':');
            valueText.text = tmp[0] + ": " + value;
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}
    private void HandleBar()
    {
        if (fillAmount != HP_Bar.fillAmount)
        {
            HP_Bar.fillAmount = Mathf.Lerp(HP_Bar.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
    //Map(Current HP 100, Lowest HP Value 0, Max HP 100, lowest fill value 0, max fill value 1);
    }
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
