using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text npcNameUI;
    public Text dialogueContentUI;
    public Animator animator;

    private Queue<string> sentences;

    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Many instances in DialogueManager");
            return;
        }
        instance = this;

        sentences = new Queue<string>();
    }

    //display name of npc
    //display the sentences 
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        npcNameUI.text = dialogue.nameNPC;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue(); // Get the next sentence
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Text animation effect
    //Write letter one by one
    IEnumerator TypeSentence(string sentence)
    {
        dialogueContentUI.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueContentUI.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
