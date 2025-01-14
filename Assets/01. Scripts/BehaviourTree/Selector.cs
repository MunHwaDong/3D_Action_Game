using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    private List<Node> _children = new List<Node>();

    public void AddChild(Node child)
    {
        _children.Add(child);
    }
    
    public override NodeState Evaluate()
    {
        foreach (var child in _children)
        {
            var result = child.Evaluate();

            if (result == NodeState.SUCCESS)
            {
                return NodeState.SUCCESS;
            }
        }
        return NodeState.FAILURE;
    }
}
