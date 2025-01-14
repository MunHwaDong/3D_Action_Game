using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : Node
{
    private MonsterController monster;

    public PatrolAction(MonsterController monster)
    {
        this.monster = monster;
        
        patrolOriginPosition = monster.transform.position;
    }
    public override NodeState Evaluate()
    {
        //Debug.Log("Patrol Action");
        
        return NodeState.RUNNING;
    }

    private const float _patrolDistance = 7f;
    private Vector3 patrolOriginPosition;
}
