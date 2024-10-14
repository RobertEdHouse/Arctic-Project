using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StateMachines
{
    public class StateMachine 
    {
        private State CurrentState;
        public void Initialize(State startingState)
        {
            CurrentState = startingState;
            startingState.Enter(); 
        }
        public void Update()
        {
            CurrentState?.UpdateState();
        }
        public void ChangeState(State newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            newState.Enter();
        }
    }
}
