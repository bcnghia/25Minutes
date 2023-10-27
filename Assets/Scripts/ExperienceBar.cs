using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxExperience(float exp)
    {
        slider.maxValue = exp;
        //slider.value = exp;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetExperience(float exp)
    {
        slider.value = exp;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
