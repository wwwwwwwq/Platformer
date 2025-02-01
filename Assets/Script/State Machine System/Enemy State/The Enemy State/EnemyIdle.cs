using UnityEngine;

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
       //ÇÐ»»µ½Ñ²Âß×´Ì¬
       if(stateDuration >= idleDuration)
       {
            stateMachine.SwitchState(typeof(EnemyPatrol));
       }
    }

    public override void PhysicUpdate()
    {
        stateDuration = Time.time - startTime;
    }
}
