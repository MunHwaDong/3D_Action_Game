using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpState : IState
{
    public JumpState(StateMachine stateMachine)
    {
        FSM = stateMachine;
    }
    
    public void EnterState()
    {
        Animator anim = FSM.BlackBoard.GetData<Animator>("Animator");
        input = FSM.BlackBoard.GetData<PlayerInput>("PlayerInput");
        rb = FSM.BlackBoard.GetData<Rigidbody>("Rigidbody");
        
        anim.CrossFade("Jump", 0.1f);
        rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
    }

    public void UpdateState()
    {
        if (rb.velocity.y < 0)
        {
            FSM.ChangeState<IdleState>();
            return;
        }
    }

    public void ExitState()
    {

    }

    public StateMachine FSM { get; set; }
    
    private Rigidbody rb;
    private PlayerInput input;
}
