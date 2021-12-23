using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    [HideInInspector]public GameObject virtualCamera;
    [HideInInspector]public GameObject mainCamera;

    private static CameraManager _instance;
    private void Awake()
    {
        if (_instance != null) Destroy(gameObject);
        else
        {
            _instance = this;
            virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera");
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(virtualCamera);
            DontDestroyOnLoad(mainCamera);
            virtualCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow
                = GameObject.FindGameObjectWithTag("Player").transform;
        }

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
