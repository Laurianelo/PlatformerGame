
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool gameIdPaused = false;
    public GameObject pauseUI;

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
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
