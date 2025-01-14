using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatesFactory : IConcreteFactory
{
    public Dictionary<Type, IState> CreateStates(object obj)
    {
        StateMachine stateMachine = obj as StateMachine;
        
        Dictionary<Type, IState> states = new Dictionary<Type, IState>();
        
        states.Add(typeof(MIdleState), new MIdleState(stateMachine));
        states.Add(typeof(MWalkState), new MWalkState(stateMachine));
        states.Add(typeof(MSkillState), new MSkillState(stateMachine));
        
        stateMachine.CurrentState = states[typeof(MIdleState)] as MIdleState;
        stateMachine.CurrentState?.EnterState();
        
        return states;
    }
}
