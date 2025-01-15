using System.Collections;
using System.Collections.Generic;
using BT;
using UnityEngine;

public class PatrolAction : Node
{
    public PatrolAction(MonsterController monster)
    {
        _monsterController = monster;
        _monsterData = monster.MonsterData;
        _animator = monster.BlackBoard.GetData<Animator>(MonsterComponentsType.ANIMATOR);
    }
    
    public override NodeState Evaluate()
    {
        Debug.Log("Patrol Action");
        
        return NodeState.SUCCESS;
    }
    
    private static readonly int Speed = Animator.StringToHash("Speed");
    private readonly Vector2 _patrolDirection = Vector2.right;
    private readonly Animator _animator;
    private readonly MonsterController _monsterController;
    private readonly MonsterData _monsterData;
}
