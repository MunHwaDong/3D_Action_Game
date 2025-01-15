using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatesFactory : IConcreteFactory
{
    public (IState, IEnumerable) CreateStates()
    {
        Dictionary<Type, IState> states = new Dictionary<Type, IState>();
        
        states.Add(typeof(PlayerIdleState), new PlayerIdleState());
        states.Add(typeof(PlayerJumpState), new PlayerJumpState());
        states.Add(typeof(PlayerWalkState), new PlayerWalkState());
        states.Add(typeof(AttackCombo1State), new AttackCombo1State());
        states.Add(typeof(AttackCombo2State), new AttackCombo2State());
        states.Add(typeof(AttackCombo3State), new AttackCombo3State());
        states.Add(typeof(AttackCombo4State), new AttackCombo4State());

        return (states[typeof(PlayerIdleState)], states);
    }
}
