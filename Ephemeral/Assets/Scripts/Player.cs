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
        //DataHandler.DeleteSaveFile();
        if (DataHandler.CheckSaveFileExistance()) LoadPlayer();
        else
        {
            maxHitPoints *= (int)Mathf.Sqrt(level);
            currentHitPoints = maxHitPoints;
            xpUntilNextLevel = CalculateXpUntilNextLevel(level);
        }
    }

    private void Update()
    {
        if (currentHitPoints <= 0)
        {
            Destroy(gameObject);
            currentHitPoints = 0;

        }
        
        
        if (xpCurrent >= xpUntilNextLevel)  
        {
            xpCurrent -= xpUntilNextLevel;
            level++;
            xpUntilNextLevel = CalculateXpUntilNextLevel(level);
            maxHitPoints += 5*(int)Mathf.Sqrt(level);
            currentHitPoints += 5 * (int)Mathf.Sqrt(level);
            
        }
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
        xpUntilNextLevel = CalculateXpUntilNextLevel(level);
        UpdateHUD();

    }

    public void LoadPlayer(bool loadPosition)
    {
        if (!loadPosition) Debug.LogError("loadPosition cannot be false");
        else
        {
            PlayerData data = DataHandler.LoadPlayer();
            Vector3 oldPosition = new Vector3(data.playerTransformX, data.playerTransformY, data.playerTransformZ);
            transform.position = oldPosition;
            level = data.levelCurrent;
            xpCurrent = data.xpCurrent;
            maxHitPoints = data.healthMax;
            currentHitPoints = data.healthCurrent;
            xpUntilNextLevel = CalculateXpUntilNextLevel(level);
            UpdateHUD();
        }
    }

    #endregion
    public void UpdateHUD()
    {
        hpBar.UpdateHealthBarMax(maxHitPoints);
        hpBar.UpdateHealthBarCurrent(currentHitPoints);
        xpBar.UpdateXpBarCurrent(xpCurrent);
        xpBar.UpdateXpBarMax(xpUntilNextLevel);
        hpBar.UpdateTextBar(currentHitPoints, maxHitPoints);
        xpBar.UpdateTextBar(xpCurrent, xpUntilNextLevel);
    }

    /// <summary>
/// Calculates the required xp for level up using a ratio of 1.1
/// </summary>
/// <param name="level"></param>
/// <returns>Experience until next level</returns>
    public int CalculateXpUntilNextLevel(int level)
    {
        int xpUntilNextLevel = 83;
        for(int i=2;i<=level;i++)
        {
            //Debug.Log("Before math: " + xpUntilNextLevel);
            xpUntilNextLevel = (int)(83 + 1.1 * xpUntilNextLevel);
            //Debug.Log("After math: " + xpUntilNextLevel);
        }
        return xpUntilNextLevel;
    }
}
