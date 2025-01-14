using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIPanel
{
    void Show();
    void Hide();
    void Update(float deltaTime);
}

public class InventoryFacadePattern : IUIPanel
{
    public void Show()
    {
        Debug.Log("InventoryFacadePattern Show");
    }

    public void Hide()
    {
        throw new System.NotImplementedException();
    }

    public void Update(float deltaTime)
    {
        throw new System.NotImplementedException();
    }
}

public class StatusViewerFacadePattern : IUIPanel
{
    public void Show()
    {
        Debug.Log("StatusViewerFacadePattern Show");
    }

    public void Hide()
    {

    }

    public void Update(float deltaTime)
    {

    }
}

public class ShopFacadePattern : IUIPanel
{
    public void Show()
    {
        Debug.Log("Shop Show");
    }

    public void Hide()
    {

    }

    public void Update(float deltaTime)
    {

    }
}

//Facade를 구현할때 보통 Command랑 같이 쓴다.
public class UIFacade : MonoBehaviour
{
    private IUIPanel uiCurrentPanel;
    
    InventoryFacadePattern inventory;
    ShopFacadePattern shop;
    StatusViewerFacadePattern status;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new InventoryFacadePattern();
        shop = new ShopFacadePattern();
        status = new StatusViewerFacadePattern();
    }

    //보통은 enum 값으로 컨트롤
    public void ShowPanel(string panelName)
    {
        if (uiCurrentPanel != null)
        {
            uiCurrentPanel.Hide();
        }
        switch (panelName)
        {
            case "Inventory":
                uiCurrentPanel = inventory;
                break;
            case "Shop":
                uiCurrentPanel = shop;
                break;
            case "Status":
                uiCurrentPanel = status;
                break;
        }
        
        if(uiCurrentPanel != null)
            uiCurrentPanel.Show();
    }

    // Update is called once per frame
    void Update()
    {
        if(uiCurrentPanel != null)
            uiCurrentPanel.Update(Time.deltaTime);
    }
}