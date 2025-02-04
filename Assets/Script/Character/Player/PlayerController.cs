using Cinemachine;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PlayerController : HealthController
{
    private GroundDetector groundDetector;
    private WallDetector wallDetector;
    private PlayerInput input;
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float runSpeed = 7f;
    public float crouchSpeed = 3f;
    private bool isCrouching => input.Crouch && IsGrounded;
    private bool isRunning => input.Run;

    [Header("Jump Settings")]
    public float jumpForce = 7f;
    public float airJumpForce = 5f;
    public float coyoteTime = 0.1f;
    private float coyoteTimeCounter;
    private bool canAirJump = true;
    private bool isJumping;

    [Header("Climb Settings")]
    public float climbSlipSpeed = 3f;
    public float wallJumpForce = 10f;
    public float wallJumpControlDelay = 0.2f;
    private bool isWallSliding;
    private bool isWallJumping;

    [Header("Input Buffer")]
    public float jumpBufferTime = 0.1f;
    private bool hasJumpBuffer;

    [Header("Corner Correction")]
    public float raycastLength = 0.7f;
    public Vector3 cornerRaycastOffset = new Vector3(0.7f, 0, 0);
    public Vector3 innerRaycastOffset = new Vector3(0.25f, 0, 0);
    public LayerMask groundLayer;
    private bool cornerCorrect;

    [Header("Camera Settings")]
    public CinemachineVirtualCamera virtualCamera;
    public float scrollSpeed = 1f;
    public float minCameraSize = 1f;
    public float maxCameraSize = 20f;

    private bool IsGrounded => groundDetector.IsGrounded;
    private bool IsTouchingWall => wallDetector.IsTouchingWall;
    //private bool IsFalling => rb.velocity.y < 0 && !IsGrounded;

    private void Awake()
    {
        groundDetector = GetComponentInChildren<GroundDetector>();
        wallDetector = GetComponentInChildren<WallDetector>();
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
        HandleWallSlide();
        HandleWallJump();
        if (virtualCamera != null) HandleCameraZoom();
        HandleCornerCorrection();
        HandleJumpBuffer();
        UpdateAnimations();
        if (currentHealth <= 0 && !isDie) Die();
    }

    #region ‰–€
    private void HandleMovement()
    {
        float speed = isCrouching ? crouchSpeed :
                     isRunning ? runSpeed : walkSpeed;

        if (input.Move)
        {
            transform.localScale = new Vector3(Mathf.Sign(input.AxesX), 1, 1);
            rb.velocity = new Vector2(speed * input.AxesX, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    #endregion

    #region „Óà»
    private void HandleJump()
    {
        // ÷ÿ÷√µÿ√Ê◊¥Ã¨
        if (IsGrounded)
        {
            canAirJump = true;
            coyoteTimeCounter = coyoteTime;
            isJumping = false;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // ¥¶¿ÌÃ¯‘æ ‰»Îª∫≥Â
        if (input.Jump)
        {
            input.SetJumpInputBufferTimer();
        }

        // ÷¥––Ã¯‘æ
        if (hasJumpBuffer)
        {
            if (IsGrounded || coyoteTimeCounter > 0)
            {
                GroundJump();
            }
            else if (IsTouchingWall)
            {
                WallJump();
            }
            else if (canAirJump && !isWallJumping)
            {
                AirJump();
            }
        }

        // ∂Ã∞¥Ã¯‘æ ±ΩµµÕ∏ﬂ∂»
        if (input.StopJump && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            isJumping = false;
        }
    }
    #endregion

    #region Ã¯‘æª∫≥Â¥¶¿Ì
    private void HandleJumpBuffer()
    {
        if (input.HasJumpInputBuffer && (IsGrounded || IsTouchingWall || canAirJump))
        {
            hasJumpBuffer = true;
            input.HasJumpInputBuffer = false;
        }
        else
        {
            hasJumpBuffer = false;
        }
    }
    #endregion

    #region ≤ªÕ¨¿‡–ÕÃ¯‘æ µœ÷
    private void GroundJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJumping = true;
        anim.Play("Jump");
    }

    private void AirJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, airJumpForce);
        canAirJump = false;
        anim.Play("AirJump");
    }

    private void WallJump()
    {
        float direction = -Mathf.Sign(transform.localScale.x);
        rb.velocity = new Vector2(direction * wallJumpForce, jumpForce);
        isWallJumping = true;
        canAirJump = true;
        StartCoroutine(ResetWallJumpControl());
        anim.Play("ClimbHop");
    }

    private IEnumerator ResetWallJumpControl()
    {
        yield return new WaitForSeconds(wallJumpControlDelay);
        isWallJumping = false;
    }
    #endregion

    #region «Ω±⁄ª¨¬‰
    private void HandleWallSlide()
    {
        if (IsTouchingWall && !IsGrounded && rb.velocity.y < 0)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, -climbSlipSpeed);
            canAirJump = true;
        }
        else
        {
            isWallSliding = false;
        }
    }
    #endregion

    #region «Ω±⁄Ã¯‘æ
    private void HandleWallJump()
    {
        if (IsTouchingWall && input.Jump)
        {
            WallJump();
        }
    }
    #endregion

    #region …„œÒª˙Àı∑≈
    private void HandleCameraZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float newSize = virtualCamera.m_Lens.OrthographicSize - scroll * scrollSpeed;
            virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(newSize, minCameraSize, maxCameraSize);
        }
    }
    #endregion

    #region Ω«¬‰–ﬁ’˝
    private void HandleCornerCorrection()
    {
        bool leftCorner = Physics2D.Raycast(transform.position + cornerRaycastOffset, Vector2.up, raycastLength, groundLayer) &&
                         !Physics2D.Raycast(transform.position + innerRaycastOffset, Vector2.up, raycastLength, groundLayer);

        bool rightCorner = Physics2D.Raycast(transform.position - cornerRaycastOffset, Vector2.up, raycastLength, groundLayer) &&
                          !Physics2D.Raycast(transform.position - innerRaycastOffset, Vector2.up, raycastLength, groundLayer);

        cornerCorrect = leftCorner || rightCorner;

        if (cornerCorrect)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position - innerRaycastOffset + Vector3.up * raycastLength,
                Vector3.left, raycastLength, groundLayer);

            if (hit.collider != null)
            {
                float adjust = hit.point.x - (transform.position.x - cornerRaycastOffset.x);
                transform.position += new Vector3(adjust, 0, 0);
                return;
            }

            hit = Physics2D.Raycast(
                transform.position + innerRaycastOffset + Vector3.up * raycastLength,
                Vector3.right, raycastLength, groundLayer);

            if (hit.collider != null)
            {
                float adjust = hit.point.x - (transform.position.x + cornerRaycastOffset.x);
                transform.position += new Vector3(adjust, 0, 0);
            }
        }
    }
    #endregion

    #region ∏¸–¬∂Øª≠◊¥Ã¨
    private void UpdateAnimations()
    {
        if (isWallJumping)
        {
            anim.Play("ClimbHop");
        }
        else if (isWallSliding)
        {
            anim.Play("ClimbSlip");
        }
        else if (!IsGrounded)
        {
            anim.Play(isJumping ? "Jump" : "Fall");
        }
        else if (isCrouching)
        {
            anim.Play("Crouch");
        }
        else if (input.Move)
        {
            anim.Play(isRunning ? "Run" : "Walk");
        }
        else if (!isDie && !isHurt)
        {
            anim.Play("Idle");
        }
    }
    #endregion

    #region  ‹…À
    public void PlayerHurt(float damage)
    {
        isHurt = true;
        anim.SetTrigger("Hurt");
        TakeDamage(damage);
        //rb.velocity = new Vector2(-transform.localScale.x * 3f, 5f);ª˜ÕÀ
    }
    public void SetPlayerHurt()
    {
        isHurt = false;
    }
    #endregion

    #region À¿Õˆ
    public void Die()
    {
        isDie = true;
        anim.Play("Die");
        enabled = false;
    }
    #endregion
}