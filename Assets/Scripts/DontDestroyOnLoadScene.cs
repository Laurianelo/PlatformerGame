using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;

    public static DontDestroyOnLoadScene instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Many instances in DontDestroyOnLoadScene");
            return;
        }
        instance = this;


        foreach (var obj in objects)
        {
            DontDestroyOnLoad(obj);
        }
    }


    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var obj in objects)
        {
            SceneManager.MoveGameObjectToScene(obj,SceneManager.GetActiveScene());
        }

    }
}
