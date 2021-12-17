using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject StartGameBtn;
    public Image fadeScreen;
    public Slider loadingSlider;
    public Slider volumeSlider;
    private AudioSource audioSource;


    #region Buttons
    private void ChangeButtonName()
    {
        TextMeshProUGUI textMeshPro = StartGameBtn.GetComponentInChildren<TextMeshProUGUI>();
        if (DataHandler.CheckSaveFileExistance())
        {
            textMeshPro.text = "CONTINUE GAME";
        }
        else
        {
            textMeshPro.text = "BEGIN ADVENTURE";
        }
    }

    public void StartGame()
    {
        StartCoroutine(Fade(5));
        if (DataHandler.CheckSaveFileExistance()) DataHandler.LoadPlayer();

    }

    IEnumerator Fade(float duration)
    {
        fadeScreen.GetComponent<CanvasGroup>().blocksRaycasts = true;
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            fadeScreen.color = new Color(fadeScreen.color.r,fadeScreen.color.g,fadeScreen.color.b, Mathf.Lerp(0, 1, counter / duration));
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        fadeScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
        StartCoroutine(LoadAsync(1));
        
    }

    IEnumerator LoadAsync(int index)
    {
        loadingSlider.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;

            yield return null;
        }
    }

    public GameObject[] mainButtons;
    private bool isInSettings = false;
    
    public void SettingsBtn()
    {
        isInSettings = true;
        for(int i = 0; i < mainButtons.Length; i++)
        {
            if (i <= 2) mainButtons[i].SetActive(false);
            else mainButtons[i].SetActive(true);
        }
    }
    public void ExitBtn() 
    { 
        Application.Quit();
    }

    public void ReturnSettings()
    {
        if (isInSettings && Input.GetKeyDown(KeyCode.Escape))
        {
            isInSettings = false;
            for (int i = 0; i < mainButtons.Length; i++)
            {
                if (i <= 2) mainButtons[i].SetActive(true);
                else mainButtons[i].SetActive(false);
            }
        }
    }

    public void VolumeSlider()
    {
        audioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volume",audioSource.volume);
    }

    #endregion


    private void Update()
    {
        VolumeSlider();
        ReturnSettings();
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        ChangeButtonName();
    }
}
