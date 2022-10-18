using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarController : MonoBehaviour
{

    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;



    public void SetEnergy(float energy)
    {
        slider.value = energy;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void SetMaxEnergy(float energy)
    {
        slider.maxValue = energy;
        slider.value = energy;

        fill.color = gradient.Evaluate(1f);

    }


}
