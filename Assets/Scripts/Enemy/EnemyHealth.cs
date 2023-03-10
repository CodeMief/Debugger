using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthBehaviour
{

    private void Start()
    {
        health = stats.Health;
    }

    public override void TakeDamage(int damage)
    {
        BroadcastMessage("OnDamageTake");
        base.TakeDamage(damage);
    }
}
