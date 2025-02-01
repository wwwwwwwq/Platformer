using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/CoyoteTime", fileName = "PlayerCoyoteTime")]
public class PlayerCoyoteTime : PlayerState
{
    [SerializeField] float coyoteTime = 0.1f;

    public override void Enter()
    {
        base.Enter();

        //È¥µôÖØÁ¦
        player.SetGravity(0f);
    }

    public override void Exit()
    {
        player.SetGravity(1f);
    }

    public override void LogicUpdate()
    {
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerJumpUp));
        }

        if (StateDuration>coyoteTime || !input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerFall));
        }
        
    }

    public override void PhysicUpdate()
    {
        player.Move(currentSpeed);
    }
}
