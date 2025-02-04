using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float jumpInputBufferTime = 0.5f;
    [SerializeField] float doublePressThreshold = 0.3f;

    InputActionMap input;

    WaitForSeconds waitJumpInputBufferTime;

    public virtual float AxesX { get; set; }
    public virtual bool IsMovePress { get; set; }
    public virtual bool HasJumpInputBuffer {  get; set; }
    public virtual bool Jump { get; set; }
    public virtual bool StopJump { get; set; }
    public virtual bool Move => AxesX != 0;
    public virtual bool Run { get; set; } = false;

    int leftPressCount = 0;
    
    int rightPressCount = 0;
    public virtual bool Crouch { get; set; }

    float lastPressTime = 0f;

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
                if(AxesX > 0)
                {
                    rightPressCount++;
                }
                else if(AxesX < 0)
                {
                    leftPressCount++;
                }
            }
            else
            {
                Run = false;
                if(AxesX > 0)
                {
                    rightPressCount = 1;
                }
                else if(AxesX < 0)
                {
                    leftPressCount = 1;
                }
            }
            lastPressTime = Time.time;
            if (leftPressCount >= 2 || rightPressCount >= 2)
            {
                if (AxesX > 0)
                {
                    rightPressCount = 0;
                }
                else if (AxesX < 0)
                {
                    leftPressCount = 0;
                }
                Run = true;
            }
        }
    }

    public void SetJumpInputBufferTimer()
    {
        //StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }

    IEnumerator JumpInputBufferCoroutine()
    {
        HasJumpInputBuffer = true;
        yield return waitJumpInputBufferTime;
        HasJumpInputBuffer = false;
    }

}