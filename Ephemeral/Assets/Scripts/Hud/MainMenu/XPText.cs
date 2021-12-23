using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPText : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().xpCurrent.ToString() + "/" + GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().xpUntilNextLevel.ToString();
    }
}
