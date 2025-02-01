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

        //跳跃
        //enemy.VoicePlayer.PlayOneShot(jumpSFX);
        enemy.SetVelocityY(jumpForce);
    }

    public override void LogicUpdate()
    {
        //如果碰到地面，则切换到待机状态
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
