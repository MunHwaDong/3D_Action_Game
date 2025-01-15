using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlackBoard
{
    public void SetData(Enum value, object data)
    {
        datas[value] = data;

        if (onChageDataEvents.TryGetValue(value, out UnityEvent changeEvent))
            changeEvent?.Invoke();
    }

    public void ListenDataChange(Enum value, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (onChageDataEvents.TryGetValue(value, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            onChageDataEvents.Add(value, thisEvent);
            thisEvent.AddListener(listener);
        }
    }

    public T GetData<T>(Enum value)
    {
        if (datas.TryGetValue(value, out object data)) return (T)data;
        else
            throw new KeyNotFoundException();
    }
    
    private IDictionary<Enum, UnityEvent> onChageDataEvents = new Dictionary<Enum, UnityEvent>();
    private IDictionary<Enum, object> datas = new Dictionary<Enum, object>();
}
