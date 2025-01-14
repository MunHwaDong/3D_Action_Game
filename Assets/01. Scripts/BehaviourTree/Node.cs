using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    public Node runningNode { get; set; }
    public abstract NodeState Evaluate();
}
