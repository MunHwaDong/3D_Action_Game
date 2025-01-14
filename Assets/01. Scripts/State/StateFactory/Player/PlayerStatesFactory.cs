using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatesFactory : IConcreteFactory
{
    public Dictionary<Type, IState> CreateStates(object obj)
    {
        StateMachine stateMachine = obj as StateMachine;
        
        Dictionary<Type, IState> states = new Dictionary<Type, IState>();

        states.Add(typeof(IdleState), new IdleState(stateMachine));
        states.Add(typeof(JumpState), new JumpState(stateMachine));
        states.Add(typeof(WalkState), new WalkState(stateMachine));
        
        stateMachine.CurrentState = states[typeof(IdleState)] as IdleState;
        stateMachine.CurrentState?.EnterState();
        
        return states;
    }
}
