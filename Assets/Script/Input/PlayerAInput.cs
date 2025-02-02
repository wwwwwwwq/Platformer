using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAInput : PlayerInput
{
    public override float AxesX => Input.GetAxis("PlayerAHorizontal");
    public override bool IsMovePress => Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D);
    public override bool Jump => Input.GetKeyDown(KeyCode.W) ? true : false;
    public override bool StopJump => Input.GetKeyUp(KeyCode.W) ? true : false;
    public override bool Crouch => Input.GetAxis("PlayerACrouch") > 0 ? true : false;
}
