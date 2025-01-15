using System.Collections;
using System.Collections.Generic;
using BT;
using UnityEngine;

public interface IConcreteBehaviourFactory
{
    Node CreateBehaviourTree(object controller);
}
