using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int levelCurrent;
    public int healthCurrent;
    public int healthMax;
    public int xpCurrent;
    public PlayerData(Player player)
    {
        levelCurrent = player.level;
        healthCurrent = player.currentHitPoints;
        healthMax = player.maxHitPoints;
        xpCurrent = player.xpCurrent;
    }


}
