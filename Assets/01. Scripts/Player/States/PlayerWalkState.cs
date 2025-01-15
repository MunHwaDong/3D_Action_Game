using System.Collections;
using System.Collections.Generic;
using RPGCharacterAnims.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : IState
{
    public void EnterState()
    {
        _animator ??= FSM.BlackBoard.GetData<Animator>(PlayerComponentsType.Animator);
        _input ??= FSM.BlackBoard.GetData<PlayerInput>(PlayerComponentsType.PlayerInput);
        _playerController ??= FSM.BlackBoard.GetData<PlayerController>(PlayerComponentsType.PlayerController);
    }

    public void UpdateState()
    {
        _moveDir = _input.actions["Move"].ReadValue<Vector2>();

        if (_moveDir == Vector2.zero)
        {
            FSM.ChangeState<PlayerIdleState>();
            return;
        }
        else
        {
            _animator.SetFloat(X, _moveDir.x);
            _animator.SetFloat(Y, _moveDir.y);
            _playerController.Movement(_moveDir);
        }

        if (_input.actions["Attack"].triggered)
        {
            FSM.ChangeState<AttackCombo1State>();
            return;
        }
        
        if (_input.actions["Jump"].triggered)
        {
            FSM.ChangeState<PlayerJumpState>();
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

    private Vector2 _moveDir;
    private PlayerController _playerController;
    private PlayerInput _input;
    private Animator _animator;
}
