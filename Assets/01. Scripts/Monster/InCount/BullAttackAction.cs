using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;
using Cysharp.Threading.Tasks;

public class BullAttackAction : Node
{
    public BullAttackAction(MonsterController monsterController)
    {
        _monsterController = monsterController;
        _anim = _monsterController.BlackBoard.GetData<Animator>(MonsterComponentsType.ANIMATOR);
    }
    
    public override NodeState Evaluate()
    {
        float actionProbability = 1f;
        
        float randSelect = Random.Range(0f, 1f);
        
        if (randSelect <= actionProbability)
        {
            _ = PlayAnimation();
            return NodeState.SUCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }

    private async UniTaskVoid PlayAnimation()
    {
        _anim.SetTrigger("Attack");
        await UniTask.WaitUntil(() => _anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f);
    }

    private Animator _anim;
    private readonly MonsterController _monsterController;
}
