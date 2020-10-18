using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange = false;
    private PlayerMovement playerMovement;
    public BoxCollider2D upGroundCollider;
    public Text pressE;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        pressE = GameObject.FindGameObjectWithTag("PressE_txt").GetComponent<Text>();
    }

    private void Update()
    {
        if(isInRange && playerMovement.isClimbing == true && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = false;
            upGroundCollider.isTrigger = false;
            return;
        }

        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            upGroundCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            pressE.enabled = true;
            isInRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pressE.enabled = false;
            isInRange = false;
            playerMovement.isClimbing = false;
            upGroundCollider.isTrigger = false;

        }
    }
}
