using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Die", fileName = "EnemyDie")]
public class EnemyDie : EnemyState
{
    public override void Enter()
    {
        base.Enter();
    }
    //死亡后的逻辑通过Animation Event Function实现
}
