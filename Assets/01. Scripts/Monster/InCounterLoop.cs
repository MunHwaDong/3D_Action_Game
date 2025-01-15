using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;

public class InCounterLoop : Node
{
    public InCounterLoop(MonsterController monsterController)
    {
        _monsterController = monsterController;
    }

    public void AddChild(Node child)
    {
        _child = child;
    }
    
    public override NodeState Evaluate()
    {
        if (EvaluateCondition())
        {
            _child.Evaluate();
            return NodeState.RUNNING;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }

    private bool EvaluateCondition()
    {
        return _monsterController.MonsterData.health > 0 ? true : false;
    }

    private Node _child;
    private readonly MonsterController _monsterController;
}
