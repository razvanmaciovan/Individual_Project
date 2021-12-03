using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int xpUntilNextLevel;
    public int xpCurrent = 0;
    public HpBar hpBar;
    public XpBar xpBar;
    public int maxHitPoints = 1;
    public int currentHitPoints = 1;
    public int level = 1;
    private void Start()
    {
        maxHitPoints *= (int)Mathf.Sqrt(level);
        currentHitPoints = maxHitPoints;
        xpUntilNextLevel = (int)Mathf.Pow(2, level);
        Debug.Log(xpUntilNextLevel);
        //hpBar.UpdateHealthBarMax(maxHitPoints);
        //hpBar.UpdateHealthBarCurrent(maxHitPoints);
        //hpBar.UpdateTextBar(maxHitPoints, maxHitPoints);
        //xpBar.UpdateTextBar(xpCurrent, xpUntilNextLevel);
        //xpBar.UpdateXpBarMax(xpUntilNextLevel);
    }

    private void Update()
    {
        if (currentHitPoints <= 0)
        {
            Destroy(gameObject);
            currentHitPoints = 0;

        }
        //xpBar.UpdateXpBarCurrent(xpCurrent);
        //xpBar.UpdateTextBar(xpCurrent, xpUntilNextLevel);
        
        if (xpCurrent >= xpUntilNextLevel)  
        {
            xpCurrent -= xpUntilNextLevel;
            level++;
            xpUntilNextLevel = (int)Mathf.Pow(2, level);
            maxHitPoints += 5*(int)Mathf.Sqrt(level);
            currentHitPoints += 5 * (int)Mathf.Sqrt(level);
            //hpBar.UpdateHealthBarMax(maxHitPoints);
            //hpBar.UpdateTextBar(currentHitPoints, maxHitPoints);
            //xpBar.UpdateXpBarMax(xpUntilNextLevel);
        }
        //hpBar.UpdateHealthBarCurrent(currentHitPoints);
        //hpBar.UpdateTextBar(currentHitPoints, maxHitPoints);
        UpdateHUD();
    }


    #region Save/Load system
    public void SavePlayer()
    {
        DataHandler.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = DataHandler.LoadPlayer();
        level = data.levelCurrent;
        xpCurrent = data.xpCurrent;
        maxHitPoints = data.healthMax;
        currentHitPoints = data.healthCurrent;
        xpUntilNextLevel = (int)Mathf.Pow(2, level);
        UpdateHUD();

    }

    public void UpdateHUD()
    {
        hpBar.UpdateHealthBarMax(maxHitPoints);
        hpBar.UpdateHealthBarCurrent(currentHitPoints);
        xpBar.UpdateXpBarCurrent(xpCurrent);
        xpBar.UpdateXpBarMax(xpUntilNextLevel);
        hpBar.UpdateTextBar(currentHitPoints, maxHitPoints);
        xpBar.UpdateTextBar(xpCurrent, xpUntilNextLevel);
    }
    #endregion
}
