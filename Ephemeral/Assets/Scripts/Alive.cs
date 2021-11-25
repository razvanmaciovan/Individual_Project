using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : MonoBehaviour
{
    public int hitPoints = 1;
    public int level = 1;
    public float xpWorth = 0.0f;

    protected virtual void TakeDamage()
    {
        if (hitPoints < 0)
        {
            GameObject.Destroy(this);
        }
        
    }

    protected virtual void DealDamage()
    {

    }
}
