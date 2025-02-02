using Unity.VisualScripting;
using UnityEngine;

public class PlayerState : ScriptableObject,IState
{
    [SerializeField] string stateName;
    [SerializeField, Range(0f,1f)] float transitionDuration = 0.1f;

    float stateStartTime;

    int stateHash;

    protected float currentSpeed;

    protected Animator animator;

    protected PlayerInput input;

    protected PlayerController player;

    protected PlayerStateMachine stateMachine;

    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;

    protected float StateDuration => Time.time - stateStartTime;

    private void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }
    public void Initialize(PlayerStateMachine stateMachine, PlayerController player, PlayerInput input, Animator animator)
    {
        this.stateMachine = stateMachine;
        this.player = player;
        this.input = input;
        this.animator = animator;
    }

    public virtual void Enter()
    {
        animator.CrossFade(stateHash, transitionDuration);
        stateStartTime = Time.time;
        Debug.Log("Player Enter State: " + stateName);
        //Debug.Log(currentSpeed);
    }

    public virtual void Exit()
    {
        
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
