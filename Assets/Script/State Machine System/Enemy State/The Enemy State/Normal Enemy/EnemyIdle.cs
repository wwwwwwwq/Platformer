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
        //����ʱ������󣬸ı䷽���л���Ѳ��״̬
        if (stateDuration >= idleDuration)
        {
            stateMachine.SwitchState(typeof(EnemyPatrol));
        }
        //�����⵽��ң��л���׷��״̬�򹥻�״̬
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
