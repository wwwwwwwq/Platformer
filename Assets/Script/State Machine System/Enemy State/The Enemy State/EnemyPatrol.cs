using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Patrol", fileName = "EnemyPatrol")]
public class EnemyPatrol : EnemyState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        //停顿的时候切换到待机状态

        //如果在检测范围内遇到玩家，切换到追击状态
    }

    public override void PhysicUpdate()
    {
       //巡逻状态的逻辑
    }
}
