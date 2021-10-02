using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;
    public static Inventory instance;
    public List<Item> content = new List<Item>();
    public Image itemImageUI;
    public Text itemNameUI;
    public Sprite emptyItemImage;
    private int currentIndexContent = 0;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Many instances in Inventory");
            return;
        }
        instance = this;
    }

    public void AddCoins(int _count)
    {
        coinsCount += _count;
        UpdateTextCoins();
    }

    public void RemoveCoins(int _count)
    {
        coinsCount -= _count;
        UpdateTextCoins();
    }


    public void UpdateTextCoins()
    {
        coinsCountText.text = coinsCount.ToString();
    }

    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemImageUI.sprite = content[currentIndexContent].img;
            itemNameUI.text = content[currentIndexContent].name;
        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
        }

    }


}
