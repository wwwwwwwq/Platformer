using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Walk", fileName = "PlayerWalk")]
public class PlayerWalk : PlayerState
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

        if (input.Run)
        {
            stateMachine.SwitchState(typeof(PlayerRun));
        }

        if (input.Crouch)
        {
            stateMachine.SwitchState(typeof(PlayerCrouch));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerJumpUp));
        }

        if (!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerCoyoteTime));
        }
        //currentSpeed = Mathf.MoveTowards(currentSpeed, walkSpeed, acceleration * Time.deltaTime);
    }

    public override void PhysicUpdate()
    {
        player.Move(player.walkSpeed);
    }
}
