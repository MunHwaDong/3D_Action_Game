using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    void Start()
    {
        DamageFieldBuilder builder = new DamageFieldBuilder(_addressablePath);
        
        List<DamageHandler> damageHandlers = new List<DamageHandler>();
        
        damageHandlers.Add(new KatanaPhysicsDamage());
        damageHandlers.Add(new KatanaCriticalDamage());

        builder.SetCollider(GetComponent<Collider>()).
            SetDamage(10f).SetCriticalDamage(30f).SetCriticalProbability(0.2f).
            SetDamageHandler(damageHandlers.ToArray());
        
        _damageField = builder.Build();
    }

    public void OnDamageField()
    {
        _damageField.OnDamageCollider();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hitable"))
        {
            _hitParticle.gameObject.SetActive(true);
            _hitParticle.Play();

            other.GetComponentInParent<MonsterController>().TakenHit(_damageField.GetCalculatedDamage());
        }
    }

    public void OffDamageField()
    {
        _damageField.OffDamageCollider();
    }
    
    [SerializeField] private ParticleSystem _hitParticle;
    private DamageField _damageField;
    private readonly string _addressablePath = "Assets/03. Prefabs/DamageData.asset";
}