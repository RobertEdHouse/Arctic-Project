using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSkiState : State
{
    public IdleSkiState(Player player, AnimationController animator) : base(player, animator)
    {
    }
    public override void EnterState(StateMachine stateMachine)
    {
        Debug.Log("Enter IdleSki State");
        _animator.IdleAnim();
        //set animation "Idle"
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        if (_player.StateType == StateType.Idle)
        {
            stateMachine.SwitchState(stateMachine.IdleState);
        }
        else if(_player.StateType == StateType.Ski)
        {
            stateMachine.SwitchState(stateMachine.SkiState);
        }
    }

    public override void ExitState(StateMachine stateMachine)
    {
        _animator.IdleAnimReset();
    }
}
