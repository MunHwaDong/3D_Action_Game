using System.Collections;
using System.Collections.Generic;
using BT;
using UnityEngine;

public class ChaseAction : Node
{
    public ChaseAction(MonsterController monster)
    {
        _monsterController = monster;
        _monsterData = monster.MonsterData;
        _animator = monster.BlackBoard.GetData<Animator>(MonsterComponentsType.ANIMATOR);
    }
    
    public override NodeState Evaluate()
    {
        _animator.SetFloat(Speed, 1f, 0.5f, Time.deltaTime);
        _animator.CrossFade("Idle", 0.3f);
        
        Vector3 dir = _monsterController.target.position - _monsterController.transform.position;
        dir = new Vector3(dir.x, 0, dir.z);
        dir.Normalize();
        
        if (Vector3.Distance(_monsterController.transform.position, _monsterController.target.position) <= 4f)
        {
            _animator.SetFloat(Speed, 0f, 0.5f, Time.deltaTime);
            _animator.CrossFade("Idle", 0.3f);
            return NodeState.SUCCESS;
        }
        else if (Vector3.Distance(_monsterController.transform.position, _monsterController.target.position) <= 30f)
        {
            _monsterController.Movement(dir);
            return NodeState.RUNNING;
        }
        
        return NodeState.FAILURE;
    }

    private readonly Animator _animator;
    private readonly MonsterController _monsterController;
    private readonly MonsterData _monsterData;
    private static readonly int Speed = Animator.StringToHash("Speed");
}
