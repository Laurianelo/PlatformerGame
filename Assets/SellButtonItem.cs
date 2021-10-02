using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Text itemName;
    public Image itemImg;
    public Text ItemPrice;
    
    public Item item;

    public void BuyItem()
    {
        Inventory inventory = Inventory.instance;

        if(inventory.coinsCount >= item.price)
        {
            //update inventory
            inventory.content.Add(item);
            inventory.UpdateInventoryUI();
            inventory.coinsCount -= item.price;
            inventory.UpdateTextCoins();
            
        }
    }
}
