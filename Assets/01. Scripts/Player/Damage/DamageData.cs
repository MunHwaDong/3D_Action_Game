using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageData", menuName = "Damage Data", order = 1)]
public class DamageData : ScriptableObject
{
    public Collider damageFieldCollider;
    
    public float damage;
    
    public float criticalDamage;
    public float criticalProbability;
}
