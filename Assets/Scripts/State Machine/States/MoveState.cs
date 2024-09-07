using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public MoveState(Player player) : base(player)
    {
    }

    public override void EnterState(StateMachine stateMachine)
    {
        Debug.Log("Enter Move State");
        
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        if (_player.StateType == StateType.Idle)
        {
            stateMachine.SwitchState(stateMachine.IdleState);
        }
        else
            Move();
    }

    private void Move()
    {
        float deltaX = _player.movementVector.x * Time.deltaTime * _player.WalkingSpeed;
        float deltaY = _player.movementVector.y * Time.deltaTime *  _player.WalkingSpeed;
        _player.transform.Translate(deltaX, 0, deltaY);
    }
}
