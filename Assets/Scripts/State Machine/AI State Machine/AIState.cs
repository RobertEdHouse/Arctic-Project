

namespace StateMachines
{
    public abstract class AIState : State
    {
        protected Burya burya;
        protected Player player;


        public AIState(StateMachine stateMachine,Burya burya, Player player) : base(stateMachine) 
        {
            this.burya = burya;
            this.player = player;
        }
    }
}
