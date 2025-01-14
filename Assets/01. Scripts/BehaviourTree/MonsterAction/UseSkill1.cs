using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UseSkill1 : Node
{
    public UseSkill1(MonsterController monster)
    {
        this.monster = monster;
    }
    public override NodeState Evaluate()
    {
        Collider[] player = Physics.OverlapBox(monster.transform.position, new Vector3(3f, 3f, 3f), Quaternion.identity,
            1 << LayerMask.NameToLayer("Player"));

        WaitForSpell(player);
        
        return NodeState.SUCCESS;
    }

    private async UniTaskVoid WaitForSpell(Collider[] player)
    {
        Animator anim = monster.monsterBlackBoard.GetData<Animator>("Animator");
        anim.Rebind();
        anim.CrossFade("Skill", 0.1f);
        
        await UniTask.Delay(TimeSpan.FromSeconds(3f));

        foreach (Collider c in player)
        {
            c.attachedRigidbody.AddExplosionForce(15f, monster.transform.position, 5f);
        }
        
        anim.SetFloat("Speed", 0f);
        anim.CrossFade("Idle", 0.2f);
    }
    
    private MonsterController monster;
}
