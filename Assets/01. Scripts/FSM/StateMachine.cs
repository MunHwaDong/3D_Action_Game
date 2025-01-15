using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public void RunStateMachine<T>(BlackBoard blackBoard) where T : IConcreteFactory
    {
        var defaultStateDictTuple = StateFactory.CreateStates<T>();
        
        _currentState = defaultStateDictTuple.Item1;
        _states = defaultStateDictTuple.Item2 as Dictionary<Type, IState>;
        
        BlackBoard = blackBoard;

        if (_states != null)
            foreach (var (_, state) in _states)
                state.FSM = this;
        else
            throw new NullReferenceException("Not Created States Dictionary");

        ChangeState(_currentState);
    }
    
    public void ChangeState<T>()
    {
        _currentState?.ExitState();
        
        _currentState = _states[typeof(T)];
        
        _currentState?.EnterState();
    }
    
    public void ChangeState(IState state)
    {
        _currentState?.ExitState();
        
        _currentState = _states[state.GetType()];
        
        _currentState?.EnterState();
    }

    void Update()
    {
        _currentState.UpdateState();
    }
    
    private IState _currentState;
    private IDictionary<Type, IState> _states = new Dictionary<Type, IState>();

    public BlackBoard BlackBoard { get; private set; }
}
