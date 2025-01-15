using System.Collections;
using System.Collections.Generic;
using BT;
using UnityEngine;

namespace BT
{
    public class Selector : Node
    {
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

                    if (result == NodeState.SUCCESS)
                    {
                        return NodeState.SUCCESS;
                    }
                    else if (result == NodeState.RUNNING)
                    {
                        runningNode = child;
                        return NodeState.RUNNING;
                    }
                }
                return NodeState.FAILURE;
            }
        }

        public void AddChild(Node node)
        {
            _children.Add(node);
        }
    
        private readonly List<Node> _children = new List<Node>();
    }

}