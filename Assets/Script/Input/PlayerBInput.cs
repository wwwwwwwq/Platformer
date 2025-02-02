using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBInput : PlayerInput
{
    public override float AxesX => Input.GetAxis("PlayerBHorizontal");
    public override bool IsMovePress => Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow);
    public override bool Jump => Input.GetKeyDown(KeyCode.UpArrow) ? true : false;
    public override bool StopJump => Input.GetKeyUp(KeyCode.UpArrow) ? true : false;
    public override bool Crouch => Input.GetAxis("PlayerBCrouch") > 0 ? true : false;
}
