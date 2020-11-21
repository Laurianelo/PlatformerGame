
using UnityEngine;

public class SnakeWeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public AudioClip KillEnemySound;
    //Destroys enemy when player enter on collision over the enemy 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(KillEnemySound, transform.position);

            Destroy(objectToDestroy);
        }
    }
}
