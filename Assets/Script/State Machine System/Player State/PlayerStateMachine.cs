<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] PlayerState[] states;

    Animator animator;

    PlayerController player;

    PlayerInput input;

    public void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GetComponentInChildren<PlayerController>();
        input = GetComponent<PlayerInput>();
        stateTable = new Dictionary<System.Type, IState>(states.Length);

        // ³õÊ¼»¯Íæ¼Ò×´Ì¬
        foreach (var state in states)
        {
            state.Initialize(this, player, input, animator);
            stateTable.Add(state.GetType(), state);
        }
    }

    public void Start()
    {
        SwitchOn(stateTable[typeof(PlayerIdle)]);
    }
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] PlayerState[] states;

    Animator animator;

    PlayerController player;

    PlayerInput input;

    public void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GetComponentInChildren<PlayerController>();
        input = GetComponent<PlayerInput>();
        stateTable = new Dictionary<System.Type, IState>(states.Length);

        // ï¿½ï¿½Ê¼ï¿½ï¿½ï¿½ï¿½ï¿½×´Ì¬
        foreach (var state in states)
        {
            state.Initialize(this, player, input, animator);
            stateTable.Add(state.GetType(), state);
        }
    }

    public void Start()
    {
        SwitchOn(stateTable[typeof(PlayerIdle)]);
    }
>>>>>>> Stashed changes
}