using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Idle",fileName = "EnemyIdle")]
public class EnemyIdle : EnemyState
{
    [SerializeField] float idleDuration = 0.1f;

    float stateDuration;

    float startTime;

    public override void Enter()
    {
        base.Enter();

        startTime = Time.time;
    }

    public override void LogicUpdate()
    {
        //待机时间结束后，改变方向，切换到巡逻状态
        if (stateDuration >= idleDuration)
        {
            stateMachine.SwitchState(typeof(EnemyPatrol));
        }
        //如果检测到玩家，切换到追击状态或攻击状态
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
        stateDuration = Time.time - startTime;
    }
}
