using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    [HideInInspector]public GameObject HUD;
    private void Awake()
    {
        HUD = GameObject.FindGameObjectWithTag("HUD");
        DontDestroyOnLoad(this);

        HUD.GetComponent<Canvas>().worldCamera = Camera.main.GetComponent<Camera>();
        DontDestroyOnLoad(HUD);
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
