using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class GunSO : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private float fireSpeed;
    [SerializeField] private int maxAmmo;
    [SerializeField] private int clipSize;
    [SerializeField] private float reloadSpeed;
    public int Damage { get => damage; }
    public float FireSpeed { get => fireSpeed; }
    public int ClipSize { get => clipSize; }
    public int MaxAmmo { get => maxAmmo; }
    public float ReloadSpeed { get => reloadSpeed; }
}
