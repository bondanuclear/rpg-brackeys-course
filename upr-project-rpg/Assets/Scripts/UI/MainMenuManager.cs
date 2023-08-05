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
    
    public void LoadLevelAsync(int indexOfLevel)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(indexOfLevel);
        Debug.Log($"progress {asyncOperation.progress}");
    }

}
