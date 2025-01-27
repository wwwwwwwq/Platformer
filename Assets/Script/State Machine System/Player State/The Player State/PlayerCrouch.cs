using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Crouch", fileName = "PlayerCrouch")]
public class PlayerCrouch : PlayerState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if(!input.Crouch)
        {
            stateMachine.SwitchState(typeof(PlayerIdle));
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(crouchSpeed);
    }
}
