using System.Collections;
using System.Collections.Generic;
using BT;
using UnityEngine;

public class CheckVisibleAction : Node
{
    public CheckVisibleAction(MonsterController monster)
    {
        _monsterController = monster;
        _monsterData = _monsterController.MonsterData;
    }
    
    public override NodeState Evaluate()
    {
        Collider[] targets = Physics.OverlapBox(_monsterController.transform.position, _monsterData.visibleArea, Quaternion.identity,
            1 << LayerMask.NameToLayer("Player"));

        if (targets.Length > 0)
        {
            int randTarget = Random.Range(0, targets.Length);
            _monsterController.target = targets[randTarget].transform;
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
    }

    private readonly MonsterData _monsterData;
    private readonly MonsterController _monsterController;
}
