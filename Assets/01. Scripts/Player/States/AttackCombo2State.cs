using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackCombo2State : IState
{
    public void EnterState()
    {
        _input ??= FSM.BlackBoard.GetData<PlayerInput>(PlayerComponentsType.PlayerInput);
        _animator ??= FSM.BlackBoard.GetData<Animator>(PlayerComponentsType.Animator);
        _weapon ??= FSM.BlackBoard.GetData<Katana>(PlayerComponentsType.Katana);
        
        _weapon.OnDamageField();
        
        _animator.CrossFade("Attack2", 0.2f);
    }

    public async void UpdateState()
    {
        await UniTask.WaitUntil(() =>
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.9f &&
                _input.actions["Attack"].triggered)
            {
                FSM.ChangeState<AttackCombo3State>();
            }
            else if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                FSM.ChangeState<PlayerIdleState>();
            }

            return true;
        });
    }

    public void ExitState()
    {
        _weapon.OffDamageField();
    }

    public StateMachine FSM { get; set; }

    private Katana _weapon;
    private PlayerInput _input;
    private Animator _animator;
}
