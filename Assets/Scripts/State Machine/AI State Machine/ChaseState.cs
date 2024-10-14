using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachines
{
    public class ChaseState : AIState
    {
        private List<Zone> borders;
        private Zone zone1;
        private Zone zone3;
        public ChaseState(StateMachine stateMachine, Burya burya, Player player) : base(stateMachine, burya, player)
        {
            zone1 = burya.zone1;
            zone3 = burya.zone3;
            borders = burya.borders;
        }

        public override void Enter()
        {
            zone1.OnExitZone += ToWanderingState;
            zone3.OnEnterZone += ToAttakState;
            //burya.SetSpeed(burya.chaseSpeed);
            borders.ForEach(border => border.OnEnterZone += ToTeleportationState);
        }

        public override void Exit()
        {
            zone1.OnExitZone -= ToWanderingState;
            borders.ForEach(border => border.OnEnterZone -= ToTeleportationState);
        }

        public override void UpdateState()
        {
            burya.MoveToPoint(player.transform);
        }
        private void ToWanderingState(Vector3 enterPoint)
        {
            stateMachine.ChangeState(burya.wanderingState);
        }
        private void ToTeleportationState(Vector3 enterPoint)
        {
            burya.TeleportToPoint(enterPoint);
            stateMachine.ChangeState(burya.teleportationState);
        }
        private void ToAttakState(Vector3 enterPoint)
        {
            stateMachine.ChangeState(burya.attackState);
        }
    }
}
