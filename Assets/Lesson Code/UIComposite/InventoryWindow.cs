using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IUIComponent
{
    void Initialize();
    void SetActive(bool isActive);
    void UpdateUI();
    void ResetState();
}

public class InventoryWindow : MonoBehaviour, IUIComponent
{
    private List<IUIComponent> components = new List<IUIComponent>();

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        foreach (var uiComponent in components)
        {
            uiComponent.UpdateUI();
        }
    }
    
    public void Initialize()
    {
        foreach (var uiComponent in GetComponentsInChildren<IUIComponent>().Where(iuiComponent => iuiComponent is not InventoryWindow))
        {
            components.Add(uiComponent);
        }
        
        foreach (var uiComponent in components)
        {
            uiComponent.Initialize();
        }
    }

    public void SetActive(bool isActive)
    {
        foreach (var uiComponent in components)
        {
            uiComponent.SetActive(isActive);
        }

        gameObject.SetActive(isActive);
    }

    public void UpdateUI()
    {
        foreach (var uiComponent in components)
        {
            uiComponent.UpdateUI();
        }
    }

    public void ResetState()
    {
        foreach (var uiComponent in components)
        {
            uiComponent.ResetState();
        }
    }
}