using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachines
{
    public class TeleportationState : AIState
    {
        public TeleportationState(StateMachine stateMachine, Burya burya, Player player) : base(stateMachine, burya, player)
        {
        }

        public override void Enter()
        {
            stateMachine.ChangeState(burya.wanderingState);
        }

        public override void Exit()
        {

        }

        public override void UpdateState()
        {

        }
    }
}