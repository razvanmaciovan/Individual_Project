using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SwordManager
    List<GameObject> swordList;
    private int playerLevel;

    [Header("SwordManager")]
    public GameObject woodSword;
    public GameObject katanaSword;
    public GameObject sharkSword;


    #endregion

    private void Start()
    {
        //Adding all weapons to a list , to enable/disable them accordingly
        swordList = new List<GameObject>();
        swordList.Add(woodSword);
        swordList.Add(katanaSword);
        swordList.Add(sharkSword);

    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().level;
            ChangeWeapons();
        }
    }


    private void ChangeWeapons()
    {
        if (playerLevel <= 5) EnableWeapon(swordList[0]);
        else if (playerLevel <= 10) EnableWeapon(swordList[1]);
        else EnableWeapon(swordList[swordList.Count - 1]);

    }
    private void EnableWeapon(GameObject currentSword)
    {
        for(int i = 0; i < swordList.Count; i++)
        {
            if (currentSword == swordList[i]) currentSword.SetActive(true);
            else swordList[i].SetActive(false);
        }
    }
}
