using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyV1Attack : MonoBehaviour
{
    [SerializeField] int damage = 25;
    HealthBehaviour target;
    Random rand = new Random();

    void Start()
    {
        target = FindObjectOfType<HealthBehaviour>();
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        if (rand.Next(0, 2) == 0)
        {
            target.TakeDamage(damage);
        }
        else return;
    }
}
