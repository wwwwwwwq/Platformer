using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Attack", fileName = "EnemyAttack")]
public class EnemyAttack : EnemyState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        //当动画播放完毕，切换到待机状态
        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(EnemyIdle));
        }
    }
}
