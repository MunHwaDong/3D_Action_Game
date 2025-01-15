using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaPhysicsDamage : DamageHandler
{
    public override float HandleDamage(float damage, DamageData damageData)
    {
        damage += damageData.damage;
        return nextHandler?.HandleDamage(damage, damageData) ?? damage;
    }
}
