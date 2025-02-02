using System.Collections;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/ClimbHop", fileName = "PlayerClimbHop")]
public class PlayerClimbHop : PlayerState
{
    [SerializeField] float hopForce = 2f;
    [SerializeField] float hopDuration = 1f;
    [SerializeField] float waitForJumpAway = 0.5f;

    private float hopStartTime;

    public override void Enter()
    {
        base.Enter();
        hopStartTime = Time.time;

        player.CanWallJump = false;
        //JumpAway
        player.SetVelocity(new Vector2(-player.transform.localScale.x * hopForce, hopForce));
    }

    public override void LogicUpdate()
    {
        if (Time.time - hopStartTime > hopDuration)
        {
            stateMachine.SwitchState(typeof(PlayerFall));
        }

        if (player.IsTouchingWall && Time.time - hopStartTime > hopDuration)
        {
            stateMachine.SwitchState(typeof(PlayerClimbSlip));
            return;
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerAirJump));
        }
    }

    public override void PhysicUpdate()
    {
        player.StartCoroutine(AirMoveByInertiaCoroutine());
    }

    IEnumerator AirMoveByInertiaCoroutine()
    {
        yield return new WaitForSeconds(waitForJumpAway);

        player.SetVelocity(new Vector2(input.AxesX * hopForce, hopForce));
    }
}
