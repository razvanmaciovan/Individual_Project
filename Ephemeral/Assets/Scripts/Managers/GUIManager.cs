using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    [HideInInspector]public GameObject HUD;
    [HideInInspector] public GameObject MainMenu;
    private static GUIManager _instance;
    private void Awake()
    {
        if (_instance != null) Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
            HUD = GameObject.FindGameObjectWithTag("HUD");
            MainMenu = GameObject.FindGameObjectWithTag("MainMenu");
            DontDestroyOnLoad(this);

            HUD.GetComponent<Canvas>().worldCamera = Camera.main.GetComponent<Camera>();
            DontDestroyOnLoad(HUD);
            DontDestroyOnLoad(MainMenu);
        }

    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HUD.GetComponent<Canvas>().worldCamera = Camera.main.GetComponent<Camera>();
    }

}
