using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public void RunMachine<T>(BlackBoard blackBoard)
    {
        BlackBoard = blackBoard;
        states = StateFactory.CreateStates<T>(this);
    }
    
    public void ChangeState<T>()
    {
        CurrentState?.ExitState();

        CurrentState = states[typeof(T)];
        
        CurrentState?.EnterState();
    }
    
    public void ChangeState(Type type)
    {
        CurrentState?.ExitState();

        CurrentState = states[type];
        
        CurrentState?.EnterState();
    }
    
    void Update()
    {
        CurrentState.UpdateState();
    }

    public IState CurrentState { get; set; }

    private Dictionary<Type, IState> states = new Dictionary<Type, IState>();
    public BlackBoard BlackBoard { get; private set; }
}
