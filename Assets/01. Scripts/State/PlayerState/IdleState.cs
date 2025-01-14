using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class IdleState : IState
{
    public IdleState(StateMachine stateMachine)
    {
        FSM = stateMachine;
    }
    
    public void EnterState()
    {
        Animator anim = FSM.BlackBoard.GetData<Animator>("Animator");
        input = FSM.BlackBoard.GetData<PlayerInput>("PlayerInput");
        
        anim.Rebind();
        anim.CrossFade("Idle", 0.1f);
    }
    
    public void UpdateState()
    {
        if (input.actions["Jump"].triggered && FSM.BlackBoard.GetData<Rigidbody>("Rigidbody").velocity.y <= 0)
        {
            FSM.ChangeState<JumpState>();
            return;
        }

        if (input.actions["Move"].ReadValue<Vector2>() != Vector2.zero)
        {
            FSM.ChangeState<WalkState>();
            return;
        }
    }

    public void ExitState()
    {
        
    }

    public StateMachine FSM { get; set; }
    private PlayerInput input;
}
