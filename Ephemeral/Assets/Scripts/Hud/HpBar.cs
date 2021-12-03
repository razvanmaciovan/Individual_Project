using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void UpdateHealthBarMax( int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        fill.color = gradient.Evaluate(1f);
        
    }

    public void UpdateHealthBarCurrent(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void UpdateTextBar(int currentHealth,int maxHealth)
    {
         gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
