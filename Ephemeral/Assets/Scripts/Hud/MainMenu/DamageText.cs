using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = ((int)(GameObject.FindGameObjectWithTag("Sword").GetComponent<Sword>().damage * Mathf.Sqrt(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().level))).ToString();
    }
}
