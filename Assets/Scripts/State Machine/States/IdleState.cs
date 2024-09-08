using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Player player, AnimationController animator) : base(player, animator)
    {
        
    }

    public override void EnterState(StateMachine stateMachine)
    {
        Debug.Log("Enter Idle State");
        _animator.IdleAnim();
        //set animation "Idle"
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        if (_player.StateType == StateType.IdleSki)
        {
            stateMachine.SwitchState(stateMachine.IdleSkiState);
        }
        else if(_player.StateType == StateType.Move)
        {
            stateMachine.SwitchState(stateMachine.MoveState);
        }
    }
    public override void ExitState(StateMachine stateMachine)
    {
        _animator.IdleAnimReset();
    }
}
