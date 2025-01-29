using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Hurt", fileName = "PlayerHurt")]
public class PlayerHurt : PlayerState
{
    [SerializeField] float hurtDuration = 0.1f;

    float startTime;

    float stateDuratoin;
    public override void Enter()
    {
        base.Enter();

        startTime = Time.time;
    }

    public override void LogicUpdate()
    {
        if(stateDuratoin >= hurtDuration)
        {
            stateMachine.SwitchState(typeof(PlayerIdle));
        }
    }

    public override void PhysicUpdate()
    {
        stateDuratoin = Time.time - startTime;
    }
}
