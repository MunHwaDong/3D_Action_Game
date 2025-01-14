using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkState : IState
{
    public WalkState(StateMachine stateMachine)
    {
        FSM = stateMachine;
    }
    
    public void EnterState()
    {
        Animator anim = FSM.BlackBoard.GetData<Animator>("Animator");
        input = FSM.BlackBoard.GetData<PlayerInput>("PlayerInput");
        rb = FSM.BlackBoard.GetData<Rigidbody>("Rigidbody");
        
        anim.CrossFade("Idle", 0.1f);
        anim.SetFloat(Speed, 1f);
    }

    public void UpdateState()
    {
        if (input.actions["Move"].ReadValue<Vector2>() == Vector2.zero)
        {
            FSM.ChangeState<IdleState>();
            return;
        }
        else
        {
            Vector2 movementVector = input.actions["Move"].ReadValue<Vector2>();
            
            rb.velocity = new Vector3(movementVector.x * movementSpeed,
                                        rb.velocity.y,
                                        movementVector.y * movementSpeed);
            
            rb.rotation = Quaternion.LookRotation(new Vector3(movementVector.x, rb.transform.position.y, movementVector.y), Vector3.up);
        }
    }

    public void ExitState()
    {
    }

    public StateMachine FSM { get; set; }
    
    private Rigidbody rb;
    private PlayerInput input;
    private readonly float movementSpeed = 3f;
    private static readonly int Speed = Animator.StringToHash("Speed");
}
