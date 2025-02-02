using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "PlayerFall")]
public class PlayerFall : PlayerState
{
    [SerializeField] AnimationCurve speedCurve;

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if(player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerLand));
            Debug.Log("PlayerLand");
        }

        if (input.Jump)
        {
            //¶þ¶ÎÌø
            if (player.CanAirJump)
            {
                stateMachine.SwitchState(typeof(PlayerAirJump));

                return;
            }

            input.SetJumpInputBufferTimer();
        }

        if (player.IsTouchingWall)
        {
            stateMachine.SwitchState(typeof(PlayerClimbSlip));
        }
    }

    public override void PhysicUpdate()
    {
        player.SetVelocityY(speedCurve.Evaluate(StateDuration));

        currentSpeed = input.Run ? player.runSpeed : player.walkSpeed;

        player.Move(player.IsTouchingWall ? 0 : currentSpeed);
    }
}
