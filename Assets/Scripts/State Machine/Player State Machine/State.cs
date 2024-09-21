using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Player _player;
    protected AnimationController _animator;
    

    public State(Player player, AnimationController animator)
    {
        _player = player;
        _animator = animator;
    }

    public virtual void EnterState(StateMachine stateMachine)
    {
        
    }

    public virtual void UpdateState(StateMachine stateMachine)
    {
       
    }

    public virtual void ExitState(StateMachine stateMachine)
    {
        
    }
}
