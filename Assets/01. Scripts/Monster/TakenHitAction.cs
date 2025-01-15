using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;

public class TakenHitAction : Node
{
    public TakenHitAction(MonsterController monster)
    {
        _monsterController = monster;

        _animator = monster.BlackBoard.GetData<Animator>(MonsterComponentsType.ANIMATOR);
    }
    
    public override NodeState Evaluate()
    {
        return NodeState.NONE;
    }
    
    private MonsterController _monsterController;
    private Animator _animator;
}
