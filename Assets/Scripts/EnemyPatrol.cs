using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    private int damagesOnCollision = 10;
    public Transform[] wayPoints;
    public SpriteRenderer graphics;

    private int destPoint;
    private Transform targetPoint;


    void Start()
    {
        targetPoint = wayPoints[0];
    }

    void Update()
    {
        Vector3 dir = targetPoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, targetPoint.position) < 0.3)
        {
            destPoint = (destPoint + 1) % wayPoints.Length;
            targetPoint = wayPoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damagesOnCollision);

        }
    }
}
