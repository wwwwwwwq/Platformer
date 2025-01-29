using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : HealthController
{

    [SerializeField] float attackRadius = 0.1f;
    [SerializeField] float chaseRadius = 0.5f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }

    public void SetVelocityX(float VelocityX)
    {
        rb.velocity = new Vector2(VelocityX, rb.velocity.y);
    }

    public void SetVelocityY(float VelocityY)
    {
        rb.velocity = new Vector2(rb.velocity.x, VelocityY);
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}
