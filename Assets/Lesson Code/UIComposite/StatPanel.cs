using UnityEngine;

public class StatPanel : MonoBehaviour, IUIComponent
{
    public int HP;
    public int Atk;
    
    public void Initialize()
    {
        //ui getcomponent와 같은 행동을 하면 된다.
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void UpdateUI()
    {
        Debug.Log($"{HP}, {Atk}");
    }

    public void ResetState()
    {
        //UI RELEASE
    }
}