using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Many instances in LoadAndSaveData");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateTextCoins();

        //download items
        string[] itemsSaved = PlayerPrefs.GetString("inventoryItems", "").Split(',');
        for (int i = 0; i < itemsSaved.Length; i++)
        {
            if (itemsSaved[i] != "")
            {
                int id = int.Parse(itemsSaved[i]);
                Item currentItem = ItemsDatabase.instance.allItems.Single(x => x.id == id);
                Inventory.instance.content.Add(currentItem);
            }


        }

        Inventory.instance.UpdateInventoryUI();
    }


    public void SavaData()
    {
        //coins
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);


        if (CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }

        //Save Item
        string ItemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("inventoryItems", ItemsInInventory);


    }
}
