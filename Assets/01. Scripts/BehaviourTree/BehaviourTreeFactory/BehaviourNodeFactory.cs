using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class BehaviourNodeFactory
{
    public static Node CreateBehaviourNode<T>(MonsterController monsterController)
    {
        if (nodeFactories.Count <= 0)
        {
            RegisterFactory();
        }
        if (nodeFactories.ContainsKey(typeof(T)))
        {
            return nodeFactories[typeof(T)].CreateBehaviourNode(monsterController);
        }
        else
        {
            throw new System.Exception("There is no node factory for this type");
        }
    }

    private static void RegisterFactory()
    {
        var factories = Assembly.GetExecutingAssembly().GetTypes().
            Where(type => typeof(IConcreteBehaviourNodeFactory).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface);

        foreach (var factory in factories)
        {
            if (Activator.CreateInstance(factory) is IConcreteBehaviourNodeFactory factoryNode)
            {
                nodeFactories.Add(factoryNode.GetType(), factoryNode);
            }
        }
    }
    
    private static IDictionary<Type, IConcreteBehaviourNodeFactory> nodeFactories = new Dictionary<Type, IConcreteBehaviourNodeFactory>();
}
