
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace StateMachines
{
    public class WanderingState : AIState
    {
        private Zone zone2;

        private List<Zone> borders;
        public WanderingState(StateMachine stateMachine, Burya burya, Player player) : base(stateMachine, burya, player)
        {
            zone2 = burya.zone1;
            borders = burya.borders;
        }

        public override void Enter()
        {
            zone2.OnEnterZone += ToChaseState;
            //burya.SetSpeed(burya.ordinarySpeed);
            borders.ForEach(border => border.OnEnterZone += ToTeleportationState);
        }

        public override void Exit()
        {
            zone2.OnEnterZone -= ToChaseState;
            borders.ForEach(border => border.OnEnterZone -= ToTeleportationState);

        }

        public override void UpdateState()
        {
            burya.MoveToPointOnTheMap();
        }
        private void ToChaseState(Vector3 enterPoint)
        {
            stateMachine.ChangeState(burya.chaseState);
        }
        private void ToTeleportationState(Vector3 enterPoint)
        {

            burya.TeleportToPoint(enterPoint);
            stateMachine.ChangeState(burya.teleportationState);
        }
    }
}
