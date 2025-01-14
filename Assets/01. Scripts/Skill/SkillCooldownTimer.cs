using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SkillCooldownTimer
{
    private float cooldownTime = 0;
    
    public event Action OnFinishedCooldownEvent;

    public SkillCooldownTimer(float t)
    {
        cooldownTime = t;

        _ = WaitForCooldown();
    }

    public async UniTaskVoid WaitForCooldown()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(cooldownTime));
        
        OnFinishedCooldownEvent?.Invoke();
    }
}
