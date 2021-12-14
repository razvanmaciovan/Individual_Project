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
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            fadeScreen.color = new Color(fadeScreen.color.r,fadeScreen.color.g,fadeScreen.color.b, Mathf.Lerp(0, 1, counter / duration));
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
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

    private void Start()
    {
        ChangeButtonName();
    }
}
