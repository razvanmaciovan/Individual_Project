using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class XpBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public void UpdateXpBarMax(int xpUntilNextLvl)
    {
        slider.maxValue = xpUntilNextLvl;
    }

    public void UpdateXpBarCurrent(int xpCurrent)
    {
        slider.value = xpCurrent;
    }

    public void UpdateTextBar(int xpCurrent, int xpUntilNextLvl)
    {
        gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = xpCurrent.ToString() + "/" + xpUntilNextLvl.ToString();
    }
}
