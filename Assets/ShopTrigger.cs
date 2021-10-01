using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    private bool isInRange;
    public Item[] itemsToSell;
    public string NPCName;
    private Text pressE;

    private void Awake()
    {
        pressE = GameObject.FindGameObjectWithTag("PressE_txt").GetComponent<Text>();
    }
    void Update()
    {
        if (isInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            ShopManager.instance.OpenShop(itemsToSell, NPCName);
        }
    }

    private void DisplayShop()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            pressE.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false; ;
            pressE.enabled = false;
            ShopManager.instance.CloseShop();
        }
    }
}
