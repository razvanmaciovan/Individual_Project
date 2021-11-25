using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : MonoBehaviour
{
    public int maxHitPoints = 1;
    public int currentHitPoints = 1;
    public int level = 1;
    public float xpWorth = 0.0f;

    private void Start()
    {
        maxHitPoints *= (int)Mathf.Sqrt(level);
        currentHitPoints = maxHitPoints;
    }

    protected virtual void Update()
    {
        TakeDamageAndDie();
        DealDamage();
    }

    protected virtual void TakeDamageAndDie()
    {
        if (currentHitPoints <= 0)
        {
            Destroy(gameObject);
            currentHitPoints = 0;
        }
        
    }

    protected virtual void DealDamage()
    {

    }
}
