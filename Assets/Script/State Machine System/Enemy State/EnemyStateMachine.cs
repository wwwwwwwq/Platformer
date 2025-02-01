using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [SerializeField] EnemyState[] states;

    Animator animator;

    EnemyController enemy;

    public void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        enemy = GetComponentInChildren<EnemyController>();

        stateTable = new Dictionary<System.Type, IState>(states.Length);

        foreach (var state in states)
        {
            state.Initialize(this, enemy, animator);
            stateTable.Add(state.GetType(), state);
        }
    }

    private void Start()
    {
        SwitchOn(stateTable[typeof(EnemyIdle)]);
    }

}
