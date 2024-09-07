using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiState : State
{
    public SkiState(Player player) : base(player)
    {
    }

    public override void EnterState(StateMachine stateMachine)
    {
        
        Debug.Log("Enter Ski State");
    }
    public override void UpdateState(StateMachine stateMachine)
    {
        if (_player.StateType == StateType.IdleSki)
        {
            stateMachine.SwitchState(stateMachine.IdleSkiState);
        }
    }
}
