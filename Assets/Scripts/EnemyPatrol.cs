using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] wayPoints;
    public SpriteRenderer graphics;


    private Transform targetPoint;
    private int destPoint;

    void Start()
    {
        targetPoint = wayPoints[0];
    }

    // Update is called once per frame
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
}
