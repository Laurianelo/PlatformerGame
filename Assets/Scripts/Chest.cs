using System;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Text pressE;
    private bool IsInRange;
    private int WinCoins;
    public Animator animator;
    public AudioClip WinCoin;
    void Awake()
    {
        pressE = GameObject.FindGameObjectWithTag("PressE_txt").GetComponent<Text>();
    }

    //if E is pressed and player near chest -> Openchest()
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsInRange == true)
        {
            OpenChest();
        }
    }

     ///Trigger animation
     ///Add random coin(s)
     ///Disable collider -> prohibit reopening chest
     ///Disable Text
    private void OpenChest()
    {
        animator.SetTrigger("OpenChestTrigger");
        WinCoins = UnityEngine.Random.Range(1, 50);
        Inventory.instance.AddCoins(WinCoins);
        AudioManager.instance.PlayClipAt(WinCoin, transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
        pressE.enabled = false;
    }

    //enable text and bool
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            pressE.enabled = true;
            IsInRange = true;
        }
    }

    //Disable text and bool
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pressE.enabled = false;
            IsInRange = false;
        }
    }

}
