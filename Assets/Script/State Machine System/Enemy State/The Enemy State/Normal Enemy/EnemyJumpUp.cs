using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/JumpUp", fileName = "EnemyJumpUp")]
public class EnemyJumpUp : EnemyState
{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] AudioClip jumpSFX;


    public override void Enter()
    {
        base.Enter();

        //��Ծ
        //enemy.VoicePlayer.PlayOneShot(jumpSFX);
        enemy.SetVelocityY(jumpForce);
    }

    public override void LogicUpdate()
    {
        //����������棬���л�������״̬
        if (enemy.IsGrounded)
        {
            stateMachine.SwitchState(typeof(EnemyIdle));
        }
    }

    public override void PhysicUpdate()
    {
        currentSpeed = enemy.CanChasePlayer ? enemy.chaseSpeed : enemy.patrolSpeed;

        enemy.Move(currentSpeed);
    }
}
