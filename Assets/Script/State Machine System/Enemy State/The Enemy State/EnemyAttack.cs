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
        //Èç¹ûÍæ¼ÒÍÑÀë¹¥»÷·¶Î§£¬ÇÐ»»µ½×·Öð×´Ì¬
    }

    public override void PhysicUpdate()
    {
        //¹¥»÷×´Ì¬µÄÂß¼­
    }
}
