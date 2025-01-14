using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviourNodeFactory : IConcreteBehaviourNodeFactory
{
    public Node CreateBehaviourNode(MonsterController monsterController)
    {
        Selector root = new Selector();
        
        Sequence sequence = new Sequence();
        sequence.AddChild(new CheckVisiblePlayerAction(monsterController));
        sequence.AddChild(new ChasePlayerAction(monsterController));
        sequence.AddChild(new UseSkill1(monsterController));
        
        root.AddChild(sequence);

        root.AddChild(new PatrolAction(monsterController));

        return root;
    }
}
