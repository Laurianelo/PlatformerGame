
using UnityEngine;

public class SnakeWeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;

    //Destroys enemy when player enter on collision over the enemy 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(objectToDestroy);
        }
    }
}
