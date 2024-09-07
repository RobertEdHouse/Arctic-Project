using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State _currentState;

    public State IdleState;
    public State IdleSkiState;
    public  State MoveState;
    public  State SkiState;
    
    protected Player _player;
    protected Animator _animator;
    public void Start()
    {
        _player = GetComponent<Player>();
        IdleState = new IdleState(_player);
        MoveState = new MoveState(_player);
        SkiState = new SkiState(_player);
        IdleSkiState = new IdleSkiState(_player);
        _currentState = IdleState;
        IdleState.EnterState(this);
    }

    public void Update()
    {
        _currentState.UpdateState(this);
    }
    public void SwitchState(State state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        _currentState.EnterState(this);
    }
}
