using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownButton : MonoBehaviour, IUIComponent
{
    public void Initialize()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(Cooldown);
    }

    public void SetActive(bool isActive)
    {
        
    }

    public void UpdateUI()
    {
        if (!_isCooldown) return;
        else
        {
            t += Time.deltaTime;
            cooldownGradient.fillAmount = 1 - t / cooldown;

            if (t <= 0f)
            {
                _isCooldown = false;
                cooldownGradient.gameObject.SetActive(false);
                cooldownGradient.fillAmount = 1f;
            }
        }
    }

    public void ResetState()
    {
    }

    public void Cooldown()
    {
        cooldownGradient.gameObject.SetActive(true);
        _isCooldown = true;
        t = 0f;
        cooldownGradient.fillAmount = 0;
    }

    [SerializeField] private Image cooldownGradient;
    private Button _button;
    private bool _isCooldown = false;
    private float t = 0f;
    private float cooldown = 3f;
}
