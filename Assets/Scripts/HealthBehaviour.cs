using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
   [SerializeField] protected StatsSO stats;
    [SerializeField] protected int health;
    void Start()
    {
        health = stats.Health;
    }
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
