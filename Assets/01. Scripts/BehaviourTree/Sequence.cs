using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    private List<Node> _children = new List<Node>();

    public void AddChild(Node child)
    {
        _children.Add(child);
    }
    
    public override NodeState Evaluate()
    {
        if (runningNode != null)
        {
            var result = runningNode.Evaluate();

            if (result != NodeState.RUNNING)
            {
                runningNode = null;
            }
            return result;
        }
        else
        {
            foreach (var child in _children)
            {
                var result = child.Evaluate();

                if (result == NodeState.FAILURE)
                {
                    return NodeState.FAILURE;
                }
                else if (result == NodeState.RUNNING)
                {
                    runningNode = child;
                    return NodeState.RUNNING;
                }
            }
            return NodeState.SUCCESS;
        }
    }
}
