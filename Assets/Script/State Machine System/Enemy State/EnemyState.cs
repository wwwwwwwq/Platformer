using Unity.VisualScripting;
using UnityEngine;

public class EnemyState : ScriptableObject,IState
{
    [SerializeField] string stateName;
    [SerializeField, Range(0f,1f)] float transitionDuration = 0.1f;

    float stateStartTime;

    int stateHash;

    protected float currentSpeed;

    protected EnemyController enemy;

    protected EnemyStateMachine stateMachine;

    protected Animator animator;

    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;

    protected float StateDuration => Time.time - stateStartTime;

    public void Initialize(EnemyStateMachine stateMachine, EnemyController enemy, Animator animator)
    {
        this.stateMachine = stateMachine;
        this.animator = animator;
        this.enemy = enemy;
    }

    private void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }

    public virtual void Enter()
    {
        animator.CrossFade(stateName, transitionDuration);
        stateStartTime = Time.time;
        Debug.Log("Enemy Enter State: " + stateName);
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
