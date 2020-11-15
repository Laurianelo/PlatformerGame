using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Many instances in GameOverManager");
            return;
        }
        instance = this;
    }

    public GameObject gameOverUI;


    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
        if(CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }
        gameOverUI.SetActive(true);
    }

    
    public void RetryBtn()
    {
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickUpCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
        PlayerHealth.instance.Respawn();
    }


    public void MainMenuBtn()
    {

    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
