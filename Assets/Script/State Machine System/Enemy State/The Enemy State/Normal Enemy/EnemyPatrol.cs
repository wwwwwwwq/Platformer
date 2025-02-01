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
        //µ½´ïPatrol Point»òÕßÅöµ½Ç½£¬±ßÔµºó£¬ÇÐ»»µ½´ý»ú×´Ì¬
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

        //Èç¹ûÔÚ¼ì²â·¶Î§ÄÚÓöµ½Íæ¼Ò£¬ÇÐ»»µ½×·»÷×´Ì¬»òÕß¹¥»÷×´Ì¬
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
        //Ñ²Âß×´Ì¬µÄÂß¼­
        if (Vector2.Distance(patrolTarget.transform.position, enemy.transform.position) > patrolPointThreshold)
            enemy.MoveToPatrolPoint();
        else return;
    }
}
