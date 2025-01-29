using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Attack", fileName = "PlayerAttack")]
public class PlayerAttack : PlayerState
{
    public override void Enter()
    {
        base.Enter();

    }

    public override void LogicUpdate()
    {
        //如果攻击键没按下，切换到待机状态
    }

    public override void PhysicUpdate()
    {
        //攻击状态的逻辑
    }
}
