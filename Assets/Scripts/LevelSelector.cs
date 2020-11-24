using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;

    private void Start()
    {
        int tempLevelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = tempLevelReached; i < levelButtons.Length; i++)
        {
                levelButtons[i].interactable = false;
        }
    }
    public void LoadLevelPassed(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
