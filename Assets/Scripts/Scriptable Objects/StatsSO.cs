using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Stat", menuName = "Stat")]
public class StatsSO : ScriptableObject
{
   [SerializeField] private float movementSpeed;
   [SerializeField] private float jumpHeight;
    public float MovementSpeed { get => movementSpeed; }

    public float JumpHeight { get => jumpHeight; }

}
