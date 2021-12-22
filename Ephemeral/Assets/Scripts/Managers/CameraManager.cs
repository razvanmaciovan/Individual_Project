using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    [HideInInspector]public GameObject virtualCamera;
    [HideInInspector]public GameObject mainCamera;

    private void Awake()
    {
        virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(virtualCamera);
        DontDestroyOnLoad(mainCamera);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        virtualCamera.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
