using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealHeart : MonoBehaviour
{

    public int healthPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerHealth.instance.HealPlayer(healthPoints);
            Destroy(gameObject);
        }
       
    }
}
