using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV2Attack : MonoBehaviour
{
    [SerializeField] int damage = 25;
    HealthBehaviour target;

    void Start()
    {
        target = FindObjectOfType<HealthBehaviour>();
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.TakeDamage(damage);
    }
}
