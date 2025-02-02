using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run",fileName="PlayerRun")]
public class PlayerRun : PlayerState
{
    //[SerializeField] float acceleration = 5f;
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerIdle));
        }

        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerWalk));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerJumpUp));
        }

        if (input.Crouch)
        {
            stateMachine.SwitchState(typeof(PlayerCrouch));
        }

        if (!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerCoyoteTime));
        }

        //currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);
    }

    public override void PhysicUpdate()
    {
        player.Move(player.runSpeed);
    }

    public override void Exit()
    {
        input.Run = false;
    }
}
