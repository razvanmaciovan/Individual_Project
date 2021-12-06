using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public float duration = 0.4f;
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

    public void Fade()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvasGroup, canvasGroup.alpha, 1));
        
    }
    //TODO Fix bug where the bar reappears if it is hit before the coroutine is done.
    private IEnumerator DoFade(CanvasGroup canvasGroup,float start, float end)
    {
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        StartCoroutine(ReverseFade(canvasGroup, start, end));
        yield break;

    }
    
    private IEnumerator ReverseFade(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(end, start, counter / duration);
            yield return null;
        }
        yield return new WaitForSeconds(0f);
        canvasGroup.alpha = 0;
    }

}
