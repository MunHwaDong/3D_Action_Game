using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerAction : Node
{
    private static readonly int Speed = Animator.StringToHash("Speed");

    public ChasePlayerAction(MonsterController monster)
    {
        this.monster = monster;
    }
    
    public override NodeState Evaluate()
    {
        Collider[] hit = Physics.OverlapBox(monster.transform.position, new Vector3(5f, 5f, 5f), Quaternion.identity, 1 << LayerMask.NameToLayer("Player"));

        Animator animator = monster.monsterBlackBoard.GetData<Animator>("Animator");
        
        animator.SetFloat(Speed, 1f);
        animator.CrossFade("Idle", 0.1f);
        
        Vector3 direction = hit[0].transform.position - monster.transform.position;
        direction.Normalize();

        monster.monsterBlackBoard.GetData<Rigidbody>("Rigidbody").velocity = direction * 2f;
        monster.monsterBlackBoard.GetData<Rigidbody>("Rigidbody").rotation = Quaternion.LookRotation(direction);
        
        if(Vector3.Distance(hit[0].transform.position, monster.transform.position) <= 3f)
            return NodeState.SUCCESS;
        else if (Vector3.Distance(hit[0].transform.position, monster.transform.position) <= 5f)
            return NodeState.RUNNING;
        else
            return NodeState.FAILURE;
    }

    private MonsterController monster;
}
