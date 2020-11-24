using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int coinsPickUpCount;
    public Vector3 respawnPoint;
    public static CurrentSceneManager instance;
    public int levelToUnlock;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Many instances in CurrentSceneManager");
            return;
        }
        instance = this;

        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
