using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BT;
using UnityEngine;

public static class BehavioursFactory
{
    public static Node CreateBehaviours<T>(object controller)
    {
        if(_factories is null)
            GetFactoryInstance();
        
        if(_factories.TryGetValue(typeof(T), out IConcreteBehaviourFactory factory))
            return factory.CreateBehaviourTree(controller);
        else
            throw new KeyNotFoundException($"No factory found for type {typeof(T).Name}");
    }

    private static void GetFactoryInstance()
    {
        _factories = new Dictionary<Type, IConcreteBehaviourFactory>();
        
        var types = Assembly.GetExecutingAssembly().GetTypes().
            Where(type => typeof(IConcreteBehaviourFactory).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface);

        foreach (var type in types)
        {
            if(Activator.CreateInstance(type) is IConcreteBehaviourFactory factory)
                _factories.Add(type, factory);
        }
    }

    private static IDictionary<Type, IConcreteBehaviourFactory> _factories;
}
