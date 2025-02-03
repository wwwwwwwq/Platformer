<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float jumpInputBufferTime = 0.5f;

    WaitForSeconds waitJumpInputBufferTime;

    PlayerInputActions playerInputActions;

    Vector2 axes => playerInputActions.Gameplay.Axes.ReadValue<Vector2>();

    public bool HasJumpInputBuffer {  get; set; }
    public bool Jump => playerInputActions.Gameplay.Jump.WasPressedThisFrame();
    public bool StopJump => playerInputActions.Gameplay.Jump.WasReleasedThisFrame();
    public bool Move => AxesX != 0f;
    public float AxesX => axes.x;
    public bool Run => playerInputActions.Gameplay.Run.ReadValue<float>() > 0;
    public bool Crouch => playerInputActions.Gameplay.Crouch.ReadValue<float>() > 0;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        waitJumpInputBufferTime = new WaitForSeconds(jumpInputBufferTime);
    }

    private void OnEnable()
    {
        playerInputActions.Gameplay.Jump.canceled += delegate
        {
            HasJumpInputBuffer = false;
        };
    }

    //private void OnGUI()
    //{
    //    Rect rect = new Rect(200, 200, 200, 200);
    //    string message = "Has Jump Input Buffer: " + HasJumpInputBuffer;
    //    GUIStyle style = new GUIStyle();
    //    style.fontSize = 20;
    //    style.fontStyle = FontStyle.Bold;
    //    GUI.Label(rect, message, style);

    //}

    public void EnableGameplayInputs()
    {
        playerInputActions.Gameplay.Enable();
    }

    public void SetJumpInputBufferTimer()
    {
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }

    IEnumerator JumpInputBufferCoroutine()
    {
        HasJumpInputBuffer = true;
        yield return waitJumpInputBufferTime;
        HasJumpInputBuffer = false;
    }

}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float jumpInputBufferTime = 0.5f;
    [SerializeField] float doublePressThreshold = 0.3f;

    WaitForSeconds waitJumpInputBufferTime;

    //PlayerInputActions playerInputActions;

    public virtual float AxesX { get; set; }
    public virtual bool IsMovePress { get; set; }
    public virtual bool HasJumpInputBuffer {  get; set; }
    public virtual bool Jump { get; set; }
    public virtual bool StopJump { get; set; }
    public virtual bool Move => AxesX != 0;
    public virtual bool Run { get; set; } = false;
    public virtual bool Crouch { get; set; }

    float lastPressTime = 0f;
    int rightPressCount = 0;
    int leftPressCount = 0;

    private void Awake()
    {
        waitJumpInputBufferTime = new WaitForSeconds(jumpInputBufferTime);
    }

    private void Start()
    {
        HasJumpInputBuffer = false;
    }

    private void Update()
    {
        DetectDoublePress();
        //Debug.Log(axes);
    }
    //private void OnGUI()
    //{
    //    Rect rect = new Rect(200, 200, 200, 200);
    //    string message = "Has Jump Input Buffer: " + HasJumpInputBuffer;
    //    GUIStyle style = new GUIStyle();
    //    style.fontSize = 20;
    //    style.fontStyle = FontStyle.Bold;
    //    GUI.Label(rect, message, style);

    //}

    private void DetectDoublePress()
    {
        if (IsMovePress)
        {
            if (Time.time - lastPressTime < doublePressThreshold)
            {
                if (AxesX > 0)
                {
                    rightPressCount++;
                    leftPressCount = 0;
                }
                else if (AxesX < 0)
                {
                    leftPressCount++;
                    rightPressCount = 0;
                }
            }
            else
            {
                rightPressCount = 1;
                leftPressCount = 1;
            }

            lastPressTime = Time.time;

            if (rightPressCount >= 2 || leftPressCount >= 2)
            {
                // ���������¼�
                Run = true;
                if (AxesX > 0)
                {
                    rightPressCount = 0;
                }
                else if(AxesX < 0)
                {
                    leftPressCount = 0;
                }
            }
        }
    }

    public void SetJumpInputBufferTimer()
    {
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }

    IEnumerator JumpInputBufferCoroutine()
    {
        HasJumpInputBuffer = true;
        yield return waitJumpInputBufferTime;
        HasJumpInputBuffer = false;
    }

}
>>>>>>> Stashed changes
