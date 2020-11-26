using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public Text pressE;
    private bool IsInRange;
    public Item item;

    public AudioClip soundToPlay;
    void Awake()
    {
        pressE = GameObject.FindGameObjectWithTag("PressE_txt").GetComponent<Text>();
    }

    //if E is pressed and player near chest -> Openchest()
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsInRange == true)
        {
            TakeItem();
        }
    }

    ///Trigger animation
    ///Add random coin(s)
    ///Disable collider -> prohibit reopening chest
    ///Disable Text
    private void TakeItem()
    {
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        pressE.enabled = false;
        Destroy(gameObject);
    }

    //enable text and bool
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
