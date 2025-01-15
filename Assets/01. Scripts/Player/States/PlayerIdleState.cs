using System.Collections;
using System.Collections.Generic;
using RPGCharacterAnims.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : IState
{
    public void EnterState()
    {
        animator ??= FSM.BlackBoard.GetData<Animator>(PlayerComponentsType.Animator);
        input ??= FSM.BlackBoard.GetData<PlayerInput>(PlayerComponentsType.PlayerInput);
        
        animator.Rebind();
        animator.SetFloat(X, 0f);
        animator.SetFloat(Y, 0f);
        animator.CrossFade("Idle", 0.2f);
    }

    public void UpdateState()
    {
        if (input.actions["Move"].ReadValue<Vector2>() != Vector2.zero)
        {
            FSM.ChangeState<PlayerWalkState>();
            return;
        }
        if (input.actions["Jump"].triggered)
        {
            FSM.ChangeState<PlayerJumpState>();
            return;
        }
        if (input.actions["Attack"].triggered)
        {
            FSM.ChangeState<AttackCombo1State>();
            return;
        }
    }

    public void ExitState()
    {
    }

    public StateMachine FSM { get; set; }

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int X = Animator.StringToHash("x");
    private static readonly int Y = Animator.StringToHash("y");
    private Animator animator;
    private PlayerInput input;
}
