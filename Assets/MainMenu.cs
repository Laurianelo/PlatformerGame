using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject SettingsWindow;
    public void StartBtn()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsBtn()
    {
        SettingsWindow.SetActive(true);
    }

    public void QuitSettingsBtn()
    {
        SettingsWindow.SetActive(false);
    }


    public void QuitBtn()
    {
        Application.Quit();
    }
}
