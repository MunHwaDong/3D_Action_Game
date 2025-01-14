using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour, IUIComponent
{
    private List<IUIComponent> components = new List<IUIComponent>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void Initialize()
    {
        
    }

    public void SetActive(bool isActive)
    {

    }

    public void UpdateUI()
    {

    }

    public void ResetState()
    {

    }
}

public class DistanceToPlayerText : MonoBehaviour, IUIComponent
{
    public void Initialize()
    {
        
    }

    public void SetActive(bool isActive)
    {

    }

    public void UpdateUI()
    {
        
    }

    public void ResetState()
    {

    }
}