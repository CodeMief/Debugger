using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Stat", menuName = "Stat")]
public class StatsSO : ScriptableObject
{
   [SerializeField] private float movementSpeed;
    public float MovementSpeed { get => movementSpeed; }
}
