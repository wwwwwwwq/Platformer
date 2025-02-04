using System.Collections;
using UnityEngine;

public class EnemyController : HealthController
{
    //private GroundDetector groundDetector;
    private WallDetector wallDetector;
    private PlayerDetecter playerDetecter;
    //private CornerDetector cornerDetector;
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Movement Settings")]
    [SerializeField] private float chaseSpeed = 3f;
    [SerializeField] private float patrolSpeed = 1f;
    [SerializeField] private float arrivalThreshold = 0.1f;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 7f;

    [Header("Patrol Settings")]
    [SerializeField] private GameObject[] patrolPoints;
    [SerializeField] private float idleDuration = 0.5f;
    private GameObject currentPatrolPoint;
    private Vector2 moveDirection;
    private bool isPatrolling;
    private bool isIdle;

    [Header("Attack Settings")]
    [SerializeField] private Vector3 attackOffset;
    [SerializeField] private Vector2 attackSize;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float damage;
    [SerializeField] private float attackCooldown = 1f;
    private bool canAttack = true;

    private bool IsFlyEnemy => CompareTag("FlyEnemy");
    //private bool IsGrounded => groundDetector.IsGrounded;
    private bool IsTouchingWall => wallDetector.IsTouchingWall;
    //private bool IsGroundCorner => cornerDetector.IsGroundCorner;
    private bool CanChasePlayer => playerDetecter.CanChasePlayer;
    private bool CanAttackPlayer => playerDetecter.CanAttackPlayer;

    private void Awake()
    {
        wallDetector = GetComponentInChildren<WallDetector>();
        //groundDetector = GetComponentInChildren<GroundDetector>();
        playerDetecter = GetComponentInChildren<PlayerDetecter>();
        //cornerDetector = GetComponentInChildren<CornerDetector>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        //开始时进入巡逻状态
        StartPatrol();
    }

    private void Update()
    {
        if (isDie) return;

        UpdateFacingDirection();

        if (CanAttackPlayer && canAttack)
        {
            StartAttack();
        }
        else if (CanChasePlayer)
        {
            ChasePlayer();
        }
        else if (isPatrolling)
        {
            HandlePatrolMovement();
        }

        if (!CanChasePlayer)
        {
            isPatrolling = true;
        }

        //如果敌人不会飞，并且碰到墙壁，则跳跃
        if (!IsFlyEnemy && IsTouchingWall)
        {
            EnemyJumpUp();
        }
    }

    #region 巡逻
    private void StartPatrol()
    {
        if (patrolPoints.Length == 0) return;

        isPatrolling = true;
        isIdle = false;
        SelectNewPatrolPoint();
        anim.Play("Patrol");
    }

    private void HandlePatrolMovement()
    {
        if (currentPatrolPoint == null) return;

        float distance = Vector2.Distance(transform.position, currentPatrolPoint.transform.position);

        if (distance > arrivalThreshold)
        {
            moveDirection = (currentPatrolPoint.transform.position - transform.position).normalized;
            SetMovement(moveDirection * patrolSpeed);
        }
        else
        {
            StartCoroutine(IdleRoutine());
        }
    }

    private IEnumerator IdleRoutine()
    {
        isPatrolling = false;
        isIdle = true;
        anim.Play("Idle");
        SetMovement(Vector2.zero);

        yield return new WaitForSeconds(idleDuration);

        isIdle = false;
        StartPatrol();
    }

    private void SelectNewPatrolPoint()
    {
        if (patrolPoints.Length < 2) return;

        GameObject newPoint;
        do
        {
            newPoint = patrolPoints[Random.Range(0, patrolPoints.Length)];
        } while (newPoint == currentPatrolPoint);//找到不一样的patrolpoint，防止一直在一个点移动

        currentPatrolPoint = newPoint;
    }
    #endregion

    #region 追击
    private void ChasePlayer()
    {
        if (isIdle) return;

        isPatrolling = false;
        anim.Play("Chase");
        Vector2 targetDirection = (playerDetecter.colliders[0].transform.position - transform.position).normalized;
        moveDirection = targetDirection;
        SetMovement(moveDirection * chaseSpeed);
    }
    #endregion

    #region 不会飞的敌人跳跃
    private void EnemyJumpUp()
    {
        anim.Play("JumpUp");
        if (!IsFlyEnemy)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    #endregion

    #region 攻击
    private void StartAttack()
    {
        isPatrolling = false;
        canAttack = false;
        anim.Play("Attack");
        PerformAttack();
        StartCoroutine(ResetAttack());
    }

    private void PerformAttack()
    {
        // 计算基础攻击方向
        float horizontalDirection = Mathf.Sign(transform.localScale.x);
        Vector3 baseOffset = new Vector3(
            attackOffset.x * horizontalDirection,
            attackOffset.y,
            0
        );

        // 如果是飞行敌人且检测到玩家
        if (IsFlyEnemy && playerDetecter.colliders.Length > 0)
        {
            // 获取玩家位置并计算垂直方向
            Vector3 playerPos = playerDetecter.colliders[0].transform.position;
            float verticalDirection = Mathf.Sign(playerPos.y - transform.position.y);
            baseOffset.y = attackOffset.y * verticalDirection;
        }

        // 计算最终攻击位置
        Vector3 attackPosition = transform.position + baseOffset;

        Collider2D[] hits = Physics2D.OverlapBoxAll(
            attackPosition,
            attackSize,
            0,
            playerLayer
        );

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<PlayerController>(out var player))
            {
                player.PlayerHurt(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        // 计算基础偏移（考虑水平方向）
        float horizontalDirection = Mathf.Sign(transform.localScale.x);
        Vector3 baseOffset = new Vector3(
            attackOffset.x * horizontalDirection,
            attackOffset.y,
            0
        );

        // 绘制攻击区域
        Gizmos.DrawWireCube(
            transform.position + baseOffset,
            attackSize
        );
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    #endregion

    #region 更新敌人朝向
    private void UpdateFacingDirection()
    {
        if (moveDirection.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveDirection.x), 1, 1);
        }
    }
    #endregion

    #region 移动
    private void SetMovement(Vector2 velocity)
    {
        rb.velocity = IsFlyEnemy ? velocity : new Vector2(velocity.x, rb.velocity.y);
    }
    #endregion

    #region 受伤
    public void EnemyHurt(float damage)
    {
        anim.SetTrigger("Hurt");
        TakeDamage(damage);
    }
    #endregion

    #region 死亡
    public void Die()
    {
        if (isDie) return;
        isDie = true;
        anim.Play("Die");
        SetMovement(Vector2.zero);
        enabled = false;
    }
    #endregion
}