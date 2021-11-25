using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public Transform prefab;
    private int[] rotation = { -90, 0, 90 };
    private float distance = 3.84f;
    private float contor;
    void Start()
    {
        contor = transform.position.x;

        for (int i = 0; i <= 9; i++)
        { 
            

            Instantiate(prefab, new Vector3(contor, transform.position.y, 0), Quaternion.identity);
            contor += transform.position.x + distance;
            
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
