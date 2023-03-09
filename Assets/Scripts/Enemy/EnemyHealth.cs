using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private StatsSO stats;
    private int health;

    private void Start()
    {
        health = stats.Health;
    }

    public void TakeDamage(int damage)
    {
        BroadcastMessage("OnDamageTake");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
