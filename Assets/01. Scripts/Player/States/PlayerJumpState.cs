using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : IState
{
    public void EnterState()
    {
        _animator ??= FSM.BlackBoard.GetData<Animator>(PlayerComponentsType.Animator);
        _playerController ??= FSM.BlackBoard.GetData<PlayerController>(PlayerComponentsType.PlayerController);
        _transform ??= FSM.BlackBoard.GetData<Transform>(PlayerComponentsType.Transform);
        _rb ??= FSM.BlackBoard.GetData<Rigidbody>(PlayerComponentsType.Rigidbody);
        
        _playerController.Jump();

        _animator.SetTrigger("Jump");
    }

    public void UpdateState()
    {
        if (_rb.velocity.y < 0 && 
            Physics.Raycast(_transform.position, Vector3.down, out RaycastHit hit, 0.2f))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                FSM.ChangeState<PlayerIdleState>();
                return;
            }
        }
    }

    public void ExitState()
    {

    }

    public StateMachine FSM { get; set; }
    
    private Animator _animator;
    private Rigidbody _rb;
    private PlayerController _playerController;
    private Transform _transform;
}
