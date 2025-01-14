using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;
using System.Linq;
using System.Reflection;
using Assembly = System.Reflection.Assembly;

public static class StateFactory
{
    public static Dictionary<Type, IState> CreateStates<T>(object obj)
    {
        if (_stateFactories.Count == 0)
        {
            RegisterFactory();    
        }
        
        if (_stateFactories.TryGetValue(typeof(T), out IConcreteFactory factory))
        {
            return factory.CreateStates(obj);
        }
        else
        {
            throw new KeyNotFoundException("The state factory could not be created for type " + typeof(T).Name);
        }
    }

    private static void RegisterFactory()
    {
        var factoryTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => typeof(IConcreteFactory).IsAssignableFrom(type) &&
            !type.IsInterface && !type.IsAbstract);

        foreach (var factoryType in factoryTypes)
        {
            if (Activator.CreateInstance(factoryType) is IConcreteFactory instance)
            {
                _stateFactories[factoryType] = instance;
            }
        }
    }
    
    private static IDictionary<Type, IConcreteFactory> _stateFactories = new Dictionary<Type, IConcreteFactory>();
}
