using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSkillState : IState
{
    public MSkillState(StateMachine stateMachine)
    {
        FSM = stateMachine;
    }
    
    public void EnterState()
    {
        
    }

    public void UpdateState()
    {
    }

    public void ExitState()
    {
    }

    public StateMachine FSM { get; set; }
    
    private static readonly int Speed = Animator.StringToHash("Speed");
}
