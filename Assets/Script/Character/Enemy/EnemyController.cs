using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyController : HealthController
{
    GroundDetector groundDetecter;

    WallDetector wallDetector;

    PlayerDetecter playerDetecter;

    CornerDetector cornerDetector;

    [SerializeField] protected float attackRadius = 0.1f;

    [SerializeField] protected float chaseRadius = 0.5f;

    [Header("Enemy Patrol")]
    Vector2 direction;
    [SerializeField] GameObject[] patrolPoints;

    [Header("Enemy Move")]
    public float chaseSpeed = 3f;
    public float patrolSpeed = 1f;

    [Header("Enemy Attack")]
    [SerializeField] Vector3 positionOffset;
    [SerializeField] Vector2 attackSize;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float damage;

    public bool IsFlyEnemy => transform.CompareTag("FlyEnemy");
    public bool IsGrounded => groundDetecter.IsGrounded;

    public bool IsCorner => cornerDetector.IsGroundCorner;

    public bool IsTouchingWall => wallDetector.IsTouchingWall;

    public bool CanChasePlayer => playerDetecter.CanChasePlayer;

    public bool CanAttackPlayer => playerDetecter.CanAttackPlayer;

    public AudioSource VoiceEnemy { get; private set; }

    Rigidbody2D rb;

    Animator anim;

    private void Awake()
    {
        wallDetector = GetComponentInChildren<WallDetector>();

        groundDetecter = GetComponentInChildren<GroundDetector>();

        playerDetecter = GetComponentInChildren<PlayerDetecter>();

        cornerDetector = GetComponentInChildren<CornerDetector>();

        chaseRadius = playerDetecter.chaseRadius;

        attackRadius = playerDetecter.attackRadius;

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        VoiceEnemy = GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {
        if (Mathf.Sign(direction.x) != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(direction.x), 1f, 1f);
        }

        if (currentHealth <= 0 && !isDie)
        {
            Die();
        }
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

    #region Move
    public void Move(float speed)
    {
        if (IsFlyEnemy)
        {
            SetVelocity(speed * direction);
        }
        else
            SetVelocityX(speed * direction.x);
    }
    #endregion

    #region Patrol
    public GameObject GetPatrolPointAndDirection()
    {
        int index = Random.Range(0,patrolPoints.Length);

        GameObject patrolPoint = patrolPoints[index];

        direction = (patrolPoint.transform.position - transform.position).normalized;

        return patrolPoint;
    }
    public void MoveToPatrolPoint()
    {
        Move(patrolSpeed);
    }
    #endregion

    #region Chase
    public void ChaseToPlayer()
    {
        direction = (playerDetecter.colliders[0].transform.position - transform.position).normalized;

        Move(chaseSpeed);
    }
    #endregion

    #region Attack
    public void Attack()
    {
        Vector3 EnemyPosition = transform.position;
        Vector3 targetPosition = EnemyPosition + transform.localScale * positionOffset.x;

        Collider2D[] colliders = Physics2D.OverlapBoxAll(targetPosition, attackSize, playerLayer);

        foreach (var collider in colliders)
        {
            if (collider.GetComponent<PlayerController>() != null)
            {
                collider.GetComponent<PlayerController>().PlayerHurt(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + positionOffset, attackSize);
    }
    #endregion

    #region Hurt
    public void EnemyHurt(float damage)
    {
        anim.SetTrigger("Hurt");
        TakeDamage(damage);
    }
    #endregion

    #region Die
    public void Die()
    {
        isDie = true;
        anim.Play("Die");
        //处理另外的逻辑，比如调出UI等
    }
    #endregion
}
