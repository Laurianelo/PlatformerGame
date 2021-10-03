using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool isInRange;

    private Text pressE;

    private void Awake()
    {
            pressE = GameObject.FindGameObjectWithTag("PressE_txt").GetComponent<Text>();
    }
    void Update()
    {
        if(isInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
            pressE.enabled = false;
        }
    }

    private void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
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
            DialogueManager.instance.EndDialogue();
        }
    }
}
