using UnityEngine;

[RequireComponent(typeof(GunBehaviour))]
public class PlayerPistol : MonoBehaviour
{
    [SerializeField] private InputReader inputReader = default;
    private GunBehaviour gunBehaviour;
    private void Start()
    {
        gunBehaviour = GetComponent<GunBehaviour>();
    }
    private void OnEnable()
    {
        inputReader.attackEvent += Shoot;
        inputReader.reloadEvent += Reload;
    }
    private void OnDisable()
    {
        inputReader.attackEvent -= Shoot;
        inputReader.reloadEvent -= Reload;
    }

    private void Shoot()
    {
        gunBehaviour.Shoot();
    }
    private void Reload()
    {
        gunBehaviour.Reload();
    }

}