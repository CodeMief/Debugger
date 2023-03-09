using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    [SerializeField] private GunSO gun;
    [SerializeField] private Transform aimPos;
    [SerializeField] private float range = 100f;
    [SerializeField] private int currentClip;
    [SerializeField] private int totalAmmo;
    private bool isReloading = false;

    private void Start()
    {
        currentClip = gun.ClipSize;
        totalAmmo = gun.MaxAmmo - currentClip;
    }
    public void Shoot()
    {
        if (isReloading) return;
        if (!HaveAmmoInClip())
        {
            Reload();
            return;
        }
        SubtractAmmo();

        RaycastHit hit;
        Physics.Raycast(aimPos.position, aimPos.forward, out hit, range);
        if (hit.transform == null) return;
        if (hit.transform.TryGetComponent(out HealthBehaviour healthBehaviour))
        {
            healthBehaviour.TakeDamage(gun.Damage);
        }
        Debug.Log(hit.transform.name);
    }

    private void SubtractAmmo()
    {
        currentClip--;
    }

    public void Reload()
    {
        if (currentClip <= 0 && totalAmmo <= 0) return;
        totalAmmo += currentClip;
        currentClip = 0;
        StartCoroutine(ReloadCoroutine());

    }

    private IEnumerator ReloadCoroutine()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(gun.ReloadSpeed);
        if (totalAmmo < gun.ClipSize)
        {
            currentClip = totalAmmo;
            totalAmmo = 0;
        }
        else
        {
            currentClip = gun.ClipSize;
            totalAmmo -= gun.ClipSize;
        }
        isReloading = false;
        Debug.Log("Done Reloading.");
    }
    bool HaveAmmoInClip()
    {
        return currentClip > 0;
    }


}
