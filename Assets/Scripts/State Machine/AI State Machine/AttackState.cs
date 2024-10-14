using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachines
{
    public class AttackState : AIState
    {
        private Zone zone3;
        private Vector3 scale;
        private Vector3 begginingScale;
        public AttackState(StateMachine stateMachine, Burya burya, Player player) : base(stateMachine, burya, player)
        {
            zone3 = burya.zone3;
        }

        public override void Enter()
        {
            zone3.OnExitZone += ToChaseState;
            begginingScale = burya.transform.localScale;
        }

        public override void Exit()
        {
            burya.transform.localScale = begginingScale;
        }


        public override void UpdateState()
        {
            scale = burya.transform.localScale;
            if (burya.transform.localScale.x >= 2 && burya.transform.localScale.x <= 4)
            {
                scale *= 1.1f;
                burya.transform.localScale = scale;

            }
            if(burya.transform.localScale.x>4)
                burya.transform.localScale = scale / 1.1f;
        }
        private void ToChaseState(Vector3 enterPoint)
        {
            stateMachine.ChangeState(burya.chaseState);
        }
    }
}
