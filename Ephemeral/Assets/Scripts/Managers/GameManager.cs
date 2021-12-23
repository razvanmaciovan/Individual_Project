using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region GearManager
    List<GameObject> swordList;
    List<RuntimeAnimatorController> armorList;
    private int playerLevel;



    [Header("SwordManager")]
    public GameObject woodSword;
    public GameObject sharkSword;
    public GameObject katanaSword;
    public GameObject skullHammer;
    public GameObject dragonGlaive;

    [Header("ArmorManager")]
    public RuntimeAnimatorController defaultArmor;
    public RuntimeAnimatorController sharkArmor;
    public RuntimeAnimatorController samuraiArmor;
    public RuntimeAnimatorController yetiArmor;
    public RuntimeAnimatorController dragonArmor;

    #endregion

    private static GameManager _instance;
    private void Awake()
    {
        if (_instance != null) Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);

            
        }

    }

    private void Start()
    {
        //Adding all weapons to a list , to enable/disable them accordingly
        swordList = new List<GameObject>();
        swordList.Add(woodSword);
        swordList.Add(sharkSword);
        swordList.Add(katanaSword);
        swordList.Add(skullHammer);
        swordList.Add(dragonGlaive);
        //Adding all armor animator controllers to a list
        armorList = new List<RuntimeAnimatorController>();
        armorList.Add(defaultArmor);
        armorList.Add(sharkArmor);
        armorList.Add(samuraiArmor);
        armorList.Add(yetiArmor);
        armorList.Add(dragonArmor);
        ChangeGear();
    }

    private void Update()
    {
        if (Player.JustLeveledUp)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().level;
                ChangeGear();
            }
            Player.JustLeveledUp = false;
        }
    }

    public bool hasParticles = false;
    private void ChangeGear()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().level;
            if (playerLevel < 5)
            {
                EnableWeapon(swordList[0]);
                EnableArmor(armorList[0]);
                hasParticles = false;
            }
            else if (playerLevel < 10)
            {
                EnableWeapon(swordList[1]);
                EnableArmor(armorList[1]);
                hasParticles = true;
            }
            else if (playerLevel < 15)
            {
                EnableWeapon(swordList[2]);
                EnableArmor(armorList[2]);
                hasParticles = true;

            }
            else if (playerLevel < 20)
            {
                EnableWeapon(swordList[3]);
                EnableArmor(armorList[3]);
                hasParticles = true;
            }
            else
            {
                EnableWeapon(swordList[swordList.Count - 1]);
                EnableArmor(armorList[armorList.Count - 1]);
                hasParticles = false;
            }
        }


    }
    private void EnableWeapon(GameObject currentSword)
    {
        for(int i = 0; i < swordList.Count; i++)
        {
            if (currentSword == swordList[i]) currentSword.SetActive(true);
            else swordList[i].SetActive(false);
        }
    }

    private void EnableArmor(RuntimeAnimatorController currentArmor)
    {
        for (int i = 0; i < armorList.Count; i++)
        {
            if (currentArmor == armorList[i])
            {
                if (GameObject.FindGameObjectWithTag("Player"))
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().runtimeAnimatorController = currentArmor;
                }
            }
        }
    }

  
}
