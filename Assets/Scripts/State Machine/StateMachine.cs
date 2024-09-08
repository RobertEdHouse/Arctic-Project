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
    protected AnimationController _animator;
    public void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<AnimationController>();
        IdleState = new IdleState(_player, _animator);
        MoveState = new MoveState(_player, _animator);
        SkiState = new SkiState(_player, _animator);
        IdleSkiState = new IdleSkiState(_player, _animator);
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
