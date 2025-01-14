using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoard
{
    public void SetData(string key, object data)
    {
        datas[key] = data;
    }

    public T GetData<T>(string key)
    {
        if (datas.TryGetValue(key, out object data)) return (T)data;
        return default(T);
    }
    
    private IDictionary<string, object> datas = new Dictionary<string, object>();
}
