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
        //如果玩家在攻击范围内，切换到攻击状态

        //如果玩家在追击范围外，切换到待机状态
    }

    public override void PhysicUpdate()
    {
        //追击状态的逻辑
    }
}
