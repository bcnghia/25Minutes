using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class ExperienceBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text levelText;

    public void SetMaxExperience(float exp)
    {
        slider.maxValue = exp;
        //slider.value = exp;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetExperience(float exp, float level)
    {
        slider.value = exp;
        levelText.text = "LV : " + level;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
