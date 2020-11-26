using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Animator animator;
    public Text npcNameUI;
    public GameObject sellBtnPrefab;
    public Transform sellParenttn;
    public static ShopManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Many instances of ShopManager");
            return;
        }
        instance = this;
    }

    public void OpenShop(Item[] items, string npcName)
    {
        npcNameUI.text = npcName;
        UpdateItemsToSell(items);
        animator.SetBool("IsOpen", true);
    }

    //display a  button for all items
    void UpdateItemsToSell(Item[] items)
    {
        //Remove potential buttons
        for (int i = 0; i < sellParenttn.childCount; i++)
        {
            Destroy(sellParenttn.GetChild(i).gameObject);
        }

        //Instantiate a button for each item to sell
        for (int i = 0; i < items.Length; i++)
        {
            GameObject tempBtn = Instantiate(sellBtnPrefab, sellParenttn);
            SellButtonItem buttonScript = tempBtn.GetComponent<SellButtonItem>();
            buttonScript.itemName.text= items[i].name;
            buttonScript.itemImg.sprite = items[i].img;
            buttonScript.ItemPrice.text = items[i].price.ToString();

            buttonScript.item = items[i];
            tempBtn.GetComponent<Button>().onClick.AddListener(delegate { buttonScript.BuyItem(); });
        }
    }

    public void CloseShop()
    {
        animator.SetBool("IsOpen", false);
    }
}
