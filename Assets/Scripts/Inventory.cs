using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;
    public static Inventory instance;

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
        coinsCountText.text = coinsCount.ToString();

    }
}
