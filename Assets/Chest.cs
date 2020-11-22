
using UnityEngine;
using UnityEngine.UI;
public class Chest : MonoBehaviour
{

    public Text pressE;
    void Awake()
    {
        pressE = GameObject.FindGameObjectWithTag("PressE_txt").GetComponent<Text>();

    }


    void Update()
    {
        
    }
}
