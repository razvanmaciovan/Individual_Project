using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player"))
        GetComponent<TMPro.TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().level.ToString();
    }
}
