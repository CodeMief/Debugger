using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Stat", menuName = "Stat")]
public class StatsSO : ScriptableObject
{
   [SerializeField] private float movementSpeed;
   [SerializeField] private int health;
    public float MovementSpeed { get => movementSpeed; }
    public int Health { get => health; }
}
