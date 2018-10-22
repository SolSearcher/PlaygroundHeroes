//Player Health system from the Unity3D Survival Shooter tutorial 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : EntityHealth 
{

	public Slider healthSlider;
	//public Image damageImage;
	//public float flashSpeed = 5f;
	//public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
	//bool damaged;

	void Start () 
	{
		currentHealth = startingHealth;
	}

    void Update()
    {
        healthSlider.value = currentHealth;
    }

    // void Update () 
    // {
    // 	// if(damaged)
    // 	// {
    // 	// 	damageImage.color = flashColor;
    // 	// }
    // 	// else
    // 	// {
    // 	// 	damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
    // 	// }
    // 	// damaged = false;

    // }

}
