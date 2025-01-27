using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerGroundDetector groundDetector;

    PlayerWallDetector wallDetector;

    PlayerInput input;

    Rigidbody2D rb;

    [Header("Player Camera Controller")]
    public CinemachineVirtualCamera virtualCamera;
    public float scrollSpeed = 1.0f;
    public float minScale = 1f;
    public float maxScale = 20f;
    public AudioSource VoicePlayer { get; private set; }

    public bool CanAirJump { get; set; } = true;
    public bool CanWallJump { get; set; } = true;
    public bool IsGrounded => groundDetector.IsGrounded;
    public bool IsFalling => rb.velocity.y < 0f && !IsGrounded;
    public bool IsTouchingWall => wallDetector.IsTouchingWall;

    public float MoveSpeed => Mathf.Abs(rb.velocity.x);

    private void Awake()
    {
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();
        wallDetector = GetComponentInChildren<PlayerWallDetector>();
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        VoicePlayer = GetComponentInChildren<AudioSource>();
    }

    private void Start()
    {
        input.EnableGameplayInputs();
    }

    private void Update()
    {
        UpdateCameraScale();
    }

    private void UpdateCameraScale()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0)
        {
            float newSize = virtualCamera.m_Lens.OrthographicSize - scrollInput * scrollSpeed;

            newSize = Mathf.Clamp(newSize, minScale, maxScale);

            virtualCamera.m_Lens.OrthographicSize = newSize;
        }
    }

    public void Move(float speed) 
    {
        if (input.Move)
        {
            transform.localScale = new Vector3(input.AxesX, 1f, 1f);
        }
        SetVelocityX(speed * input.AxesX);
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    public void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector2(rb.velocity.x, velocityY);
    }

    public void SetGravity(float value)
    {
        rb.gravityScale = value;
    }

    public void SetForce(Vector2 value)
    {
        rb.AddForce(value, ForceMode2D.Impulse);
    }
}
