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
        //�������ڹ�����Χ�ڣ��л�������״̬
        if (enemy.CanAttackPlayer)
        {
            stateMachine.SwitchState(typeof(EnemyAttack));
        }
        //��������׷����Χ�⣬�л���Ѳ��״̬
        if (!enemy.CanChasePlayer)
        {
            stateMachine.SwitchState(typeof(EnemyPatrol));
        }
        //�����⵽ǽ�ڣ����Ҳ��Ƿ��й���������Ծ
        if (enemy.IsTouchingWall && !enemy.IsFlyEnemy)
        {
            stateMachine.SwitchState(typeof(EnemyJumpUp));
        }
    }

    public override void PhysicUpdate()
    {
        //׷��״̬���߼�
        enemy.ChaseToPlayer();
    }
}
