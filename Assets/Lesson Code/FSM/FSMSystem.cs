using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TransitionCondition
{
    public string fromState;
    public string toState;
    public string conditionMethod;
}

//Json을 읽을 클래스
[Serializable]
public class FSMConfiguration
{
    public string initState;
    public List<string> states;
    public List<string> transitions;
}

public abstract class StateBase
{
    protected FSMSystem fsm;
    
    public virtual void OnEnter() { }
    public virtual void OnUpdate() { }
    public virtual void OnExit() { }

    public void Init(FSMSystem _fsm)
    {
        fsm = _fsm;
    }
}

public class FSMSystem : MonoBehaviour
{
    private Dictionary<string, StateBase> states = new();
    private StateBase currentState;
    private FSMConfiguration fsmConfiguration;

    public void Init(string configName)
    {
        TextAsset loadedText = (TextAsset)Resources.Load(configName);
        
        //몬스터 하나당 config 하나.
        FSMConfiguration config = JsonUtility.FromJson<FSMConfiguration>(loadedText.text);

        foreach (string stateName in config.states)
        {
            Type stateType = Type.GetType(stateName);
            
            StateBase state = Activator.CreateInstance(stateType) as StateBase;

            state.Init(this);

            states[stateName] = state;
        }
    }

    private void CheckTransitions()
    {
        foreach (var transition in fsmConfiguration.transitions)
        {
            if (transition.fromState == currentState.GetType().Name)
            {
                if()
            }
        }
    }

    private bool CheckCondition(string method)
    {
        return true;
    }

    private void ChangeState(string newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }

        if (states.TryGetValue(newState, out StateBase state))
        {
            currentState = state;
            currentState.OnEnter();
        }
    }

    public string GetCurrentStateName()
    {
        return currentState.GetType().Name ?? string.Empty;
    }
}

[RequireComponent(typeof(FSMSystem))]
public class MonsterController_State : MonoBehaviour
{
    public string fsmType = "";
    
    private FSMSystem fsmSystem;

    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float maxHP = 100f;
    private float currentHP;

    void Start()
    {
        currentHP = maxHP;
    }
}
