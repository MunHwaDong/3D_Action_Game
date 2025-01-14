using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVisiblePlayerAction : Node
{
    public CheckVisiblePlayerAction(MonsterController monster)
    {
        this.monster = monster;
    }
    
    public override NodeState Evaluate()
    {
        Collider[] hit = Physics.OverlapBox(monster.transform.position, new Vector3(5f, 5f, 5f), Quaternion.identity,
            1 << LayerMask.NameToLayer("Player"));
        
        if(hit.Length > 0)
            return NodeState.SUCCESS;
        else
            return NodeState.FAILURE;
    }

    private MonsterController monster;
}
