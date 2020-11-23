
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool gameIdPaused = false;
    public GameObject pauseUI;
    public GameObject SettingsUi;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIdPaused == true)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    private void Paused()
    {
        PlayerMovement.instance.enabled = false;
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        gameIdPaused = true;

    }

    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        gameIdPaused = false;
    }

    public void MainMenuBtn()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenSettingsBtn()
    {
        SettingsUi.SetActive(true);
    }

    public void QuitSettingsBtn()
    {
        SettingsUi.SetActive(false);
    }
}
