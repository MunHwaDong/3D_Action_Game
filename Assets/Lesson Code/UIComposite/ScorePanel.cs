using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScorePanel : MonoBehaviour, IUIComponent
{
    public void Initialize()
    {
        if (TryGetComponent(out scoreText))
        {
            scoreText.text = "Delta Time : ";
        }
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void UpdateUI()
    {
        dt += Time.deltaTime;
        scoreText.text = "Delta Time : " + dt + " seconds";
    }

    public void ResetState()
    {
        scoreText.text = "Delta Time : ";
    }
    
    private TextMeshProUGUI scoreText;
    private float dt = 0f;
}
