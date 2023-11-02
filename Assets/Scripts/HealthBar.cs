using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public Text healthText;

	public void SetMaxHealth(float health)
	{
		slider.maxValue = health;
		slider.value = health;

        fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth(float health, float maxHealth)
	{
		slider.value = health;
        healthText.text = health.ToString() + " / " + maxHealth.ToString();
        fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
