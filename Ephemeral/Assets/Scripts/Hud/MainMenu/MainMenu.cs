using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject child;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            child.SetActive(!child.activeSelf);
            Time.timeScale = child.activeSelf ? 0 : 1;
        }

    }

    public void ResumeBtn()
    {
        child.SetActive(false);
        Time.timeScale = 1;
    }

    public void SettingsBtn()
    {
        Debug.Log("Settings");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
