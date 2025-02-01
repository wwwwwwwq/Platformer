using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Chase", fileName = "EnemyChase")]
public class EnemyChase : EnemyState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        //如果玩家在攻击范围内，切换到攻击状态
        if (enemy.CanAttackPlayer)
        {
            stateMachine.SwitchState(typeof(EnemyAttack));
        }
        //如果玩家在追击范围外，切换到巡逻状态
        if (!enemy.CanChasePlayer)
        {
            stateMachine.SwitchState(typeof(EnemyPatrol));
        }
        //如果检测到墙壁，并且不是飞行怪物，则进行跳跃
        if (enemy.IsTouchingWall && !enemy.IsFlyEnemy)
        {
            stateMachine.SwitchState(typeof(EnemyJumpUp));
        }
    }

    public override void PhysicUpdate()
    {
        //追击状态的逻辑
        enemy.ChaseToPlayer();
    }
}
