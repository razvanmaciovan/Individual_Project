using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [HideInInspector]public string LastScene;
    private static SceneManagement _instance;
    private void Awake()
    {
        if (_instance != null) Destroy(gameObject);
        else {
            _instance = this;
            DontDestroyOnLoad(this); 
        }

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name, this);
        LastScene = scene.name;

    }
}
