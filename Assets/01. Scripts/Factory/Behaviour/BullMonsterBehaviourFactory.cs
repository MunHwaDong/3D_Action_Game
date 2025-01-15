using System.Collections;
using System.Collections.Generic;
using BT;
using UnityEngine;

public class BullMonsterBehaviourFactory :IConcreteBehaviourFactory
{
    public Node CreateBehaviourTree(object controller)
    {
        MonsterController monsterController = controller as MonsterController;
        
        Selector root = new Selector();
        
        Sequence chaseSequence = new Sequence();
        
        chaseSequence.AddChild(new CheckVisibleAction(monsterController));
        chaseSequence.AddChild(new ChaseAction(monsterController));
        
        InCounterLoop incounterLoop = new InCounterLoop(monsterController);
        
        Selector chooseAction = new Selector();
        
        chooseAction.AddChild(new BullAttackAction(monsterController));
        
        Sequence actionSequence = new Sequence();
        actionSequence.AddChild(new CheckVisibleAction(monsterController));
        actionSequence.AddChild(new ChaseAction(monsterController));
        chooseAction.AddChild(actionSequence);
        
        incounterLoop.AddChild(chooseAction);
        
        chaseSequence.AddChild(incounterLoop);
        
        root.AddChild(chaseSequence);
        root.AddChild(new PatrolAction(monsterController));

        return root;
    }
}
