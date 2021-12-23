using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPText : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnEnable()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentHitPoints.ToString() + "/" + GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().maxHitPoints.ToString();
    }
}
