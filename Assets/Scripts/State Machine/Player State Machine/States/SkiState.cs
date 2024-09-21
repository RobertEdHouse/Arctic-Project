using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiState : State
{
    public SkiState(Player player, AnimationController animator) : base(player, animator)
    {
    }

    public override void EnterState(StateMachine stateMachine)
    {
        
        _animator.WalkAnim();
        Debug.Log("Enter Ski State");
    }
    public override void UpdateState(StateMachine stateMachine)
    {
        if (_player.StateType == StateType.IdleSki)
        {
            stateMachine.SwitchState(stateMachine.IdleSkiState);
        }
    }
    public override void ExitState(StateMachine stateMachine)
    {
        _animator.WalkAnimReset();
    }
}
