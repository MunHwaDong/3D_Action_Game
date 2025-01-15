using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;

public class BehaviourTree : MonoBehaviour
{
    public void Run<T>(MonsterController monster)
    {
        _root = BehavioursFactory.CreateBehaviours<T>(monster);
    }

    void Update()
    {
        _root.Evaluate();
    }
    
    private Node _root;
}
