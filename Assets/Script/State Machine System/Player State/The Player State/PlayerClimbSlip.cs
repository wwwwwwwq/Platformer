using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/ClimbSlip", fileName = "PlayerClimbSlip")]
public class PlayerClimbSlip : PlayerState
{
    [SerializeField] ParticleSystem slipVFX;

    [SerializeField] float climbSlipSpeed = 1f;

    public override void Enter()
    {
        base.Enter();

        //Ϊ����,�趨����ǽ���»�ʱ�Ϳ���WallJump
        player.CanWallJump = true;
    }
    public override void LogicUpdate()
    {
        if(slipVFX != null) Instantiate(slipVFX, player.transform.position, Quaternion.identity);

        //�л���climphop
        if (input.Jump && player.CanWallJump)
        {
            stateMachine.SwitchState(typeof(PlayerClimbHop));
            return;
        }

        if (input.AxesX != 0 && Mathf.Sign(input.AxesX) != Mathf.Sign(player.transform.localScale.x) && !input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerFall));
        }
    }

    public override void PhysicUpdate()
    {
        player.SetVelocityY(-climbSlipSpeed);
    }
}
