using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button newGameButton;
    [SerializeField] Button settingButton;
    [SerializeField] Button exitButton;

    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider slider;
    public void LoadLevelAsync(int indexOfLevel)
    {
        StartCoroutine(Loader(indexOfLevel));
        

    }
    IEnumerator Loader(int index)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        loadingScreen.SetActive(true);
        while(!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            slider.value = progress;
            yield return null;
        }
    }

}
