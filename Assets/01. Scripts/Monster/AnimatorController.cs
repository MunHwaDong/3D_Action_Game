using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    void Start()
    {
        _animator = GetComponent<Animator>();
        _monsterController = GetComponentInParent<MonsterController>();
        
        _monsterController.BlackBoard.ListenDataChange(MonsterComponentsType.MONSTERDATA, TakenHitAnimation);
    }

    private void TakenHitAnimation()
    {
        
    }

    private void PlayRunAnimation()
    {
        _animator.SetFloat(Speed, 1f, 0.5f, Time.deltaTime);
        _animator.CrossFade("Idle", 0.5f);
    }

    private void PlayWalkAnimation()
    {
        
    }

    private void PlayIdleAnimation()
    {
        _animator.SetFloat(Speed, 0f, 0.5f, Time.deltaTime);
        _animator.CrossFade("Idle", 0.5f);
    }
    
    private Animator _animator;
    private MonsterController _monsterController;
    private static readonly int Speed = Animator.StringToHash("Speed");
}
