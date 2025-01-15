using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaCriticalDamage : DamageHandler
{
    public override float HandleDamage(float damage, DamageData damageData)
    {
        float rand = Random.value;

        if (rand <= damageData.criticalProbability)
            damage += damageData.criticalDamage;
        else
            damage += 0;

        return nextHandler?.HandleDamage(damage, damageData) ?? damage;
    }
}
