namespace StateMachines
{
    public abstract class State
    {
        protected StateMachine stateMachine;

        public State(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public abstract void Enter();


        public abstract void UpdateState();

        public abstract void Exit();
    }
}
