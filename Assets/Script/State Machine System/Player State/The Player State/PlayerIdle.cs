using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle",fileName="PlayerIdle")]
public class PlayerIdle : PlayerState
{
    //[SerializeField] float deceleration = 5f;

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityX(0);

        currentSpeed = player.MoveSpeed;
    }

    public override void LogicUpdate()
    {
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerWalk));
        }

        if(input.Crouch)
        {
            stateMachine.SwitchState(typeof(PlayerCrouch));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerJumpUp));
        }

        if (!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerFall));
        }

        //currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
    }

    public override void PhysicUpdate()
    {
        player.SetVelocityX(currentSpeed * player.transform.localScale.x);
    }
}
