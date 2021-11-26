using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Alive
{
    private int xpUntilNextLevel;
    public int xpCurrent = 0;
    protected override void Start()
    {
        base.Start();
        xpUntilNextLevel = (int)Mathf.Pow(2, level);
        Debug.Log(xpUntilNextLevel);
    }

    protected override void Update()
    {
        base.Update();
        if (xpCurrent >= xpUntilNextLevel)  
        {
            xpCurrent -= xpUntilNextLevel;
            level++;
            xpUntilNextLevel = (int)Mathf.Pow(2, level);
        }
        
    }
}
