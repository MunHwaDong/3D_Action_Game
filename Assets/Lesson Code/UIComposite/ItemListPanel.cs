using UnityEngine;

public class ItemListPanel : MonoBehaviour, IUIComponent
{
    public void Initialize()
    {
        
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void UpdateUI()
    {
        Debug.Log("ㅁㅁㅁㅁㅁ");
        Debug.Log("ㅁㅁㅁㅁㅁ");
        Debug.Log("ㅁㅁㅁㅁㅁ");
        Debug.Log("ㅁㅁㅁㅁㅁ");
        Debug.Log("ㅁㅁㅁㅁㅁ");
    }

    public void ResetState()
    {

    }
}