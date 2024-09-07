using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Player _player;
    protected Animator _animator;
    

    public State(Player player)
    {
        _player = player;
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
