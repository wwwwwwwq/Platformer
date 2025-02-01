using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Hurt", fileName = "EnemyHurt")]
public class EnemyHurt : EnemyState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(EnemyIdle));
        }
    }
}
