using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land", fileName = "PlayerLand")]
public class PlayerLand : PlayerState
{
    //[SerializeField] float stiffTime = 0.2f;

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(Vector3.zero);
        //为测试，设定为落地后可以AirJump
        player.CanAirJump = true;
    }

    public override void LogicUpdate()
    {
        if (input.HasJumpInputBuffer || input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerJumpUp));
        }

        //if(StateDuration < stiffTime)
        //{
        //    return;
        //}

        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerWalk));
        }

        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerIdle));
        }
    }
}
