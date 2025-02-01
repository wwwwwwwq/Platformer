using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Patrol", fileName = "EnemyPatrol")]
public class EnemyPatrol : EnemyState
{
    [SerializeField] float patrolPointThreshold = 0.1f;
    GameObject patrolTarget;
    public override void Enter()
    {
        base.Enter();

        patrolTarget = enemy.GetPatrolPointAndDirection();
    }

    public override void LogicUpdate()
    {
        //����Patrol Point��������ǽ����Ե���л�������״̬
        if (enemy.IsTouchingWall || Vector2.Distance(patrolTarget.transform.position,enemy.transform.position) <= patrolPointThreshold)
        {
            if (enemy.IsFlyEnemy)
            {
                stateMachine.SwitchState(typeof(EnemyIdle));
            }
            else
            {
                if (enemy.IsCorner)
                {
                    stateMachine.SwitchState(typeof(EnemyIdle));
                }
            }
        }

        //����ڼ�ⷶΧ��������ң��л���׷��״̬���߹���״̬
        if (enemy.CanChasePlayer && !enemy.CanAttackPlayer)
        {
            stateMachine.SwitchState(typeof(EnemyChase));
        }
        else if (enemy.CanAttackPlayer)
        {
            stateMachine.SwitchState(typeof(EnemyAttack));
        }
    }

    public override void PhysicUpdate()
    {
        //Ѳ��״̬���߼�
        if (Vector2.Distance(patrolTarget.transform.position, enemy.transform.position) > patrolPointThreshold)
            enemy.MoveToPatrolPoint();
        else return;
    }
}
