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
        //������������ϣ��л�������״̬
        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(EnemyIdle));
        }
    }
}
