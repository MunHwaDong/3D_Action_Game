using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConcreteFactory
{
    (IState, IEnumerable) CreateStates();
}
