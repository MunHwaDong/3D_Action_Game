using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DamageField
{
    public DamageField(string addressablePath)
    {
        damageData = Addressables.LoadAssetAsync<DamageData>(addressablePath).WaitForCompletion();
    }
    
    public float GetCalculatedDamage()
    {
        if (damageHandler != null)
        {
            return damageHandler.HandleDamage(0, damageData);
        }
        
        return damageData.damage;
    }
    
    public void OnDamageCollider()
    {
        damageData.damageFieldCollider.isTrigger = true;
    }
    
    public void OffDamageCollider()
    {
        damageData.damageFieldCollider.isTrigger = false;
    }
    
    public readonly DamageData damageData;
    public DamageHandler damageHandler;
}
