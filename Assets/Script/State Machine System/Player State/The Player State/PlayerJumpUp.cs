using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/JumpUp", fileName = "PlayerJumpUp")]
public class PlayerJumpUp : PlayerState
{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] ParticleSystem jumpVFX;
    [SerializeField] AudioClip jumpSFX;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = player.MoveSpeed;
        input.HasJumpInputBuffer = false;
        player.SetVelocityY(jumpForce);
        //player.VoicePlayer.PlayOneShot(jumpSFX);
        if (jumpVFX!=null) Instantiate(jumpVFX, player.transform.position, Quaternion.identity);
    }

    public override void LogicUpdate()
    {
        if(input.StopJump || player.IsFalling)
        {
            stateMachine.SwitchState(typeof(PlayerFall));
        }

        if (player.IsTouchingWall)
        {
            stateMachine.SwitchState(typeof(PlayerClimbSlip));
        }
    }

    public override void PhysicUpdate()
    {
        currentSpeed = input.Run ? player.runSpeed : player.walkSpeed;

        player.Move(player.IsTouchingWall ? 0 : currentSpeed);
    }
}
