using UnityEngine;

public class PlayerPistol : MonoBehaviour
{
    [SerializeField] private int pistolDamage = 5;
    [SerializeField] private InputReader inputReader = default;
    [SerializeField] private Transform aimPos;
    [SerializeField] private float range = 100f;

    private void OnEnable()
    {
        inputReader.attackEvent += Shoot;
    }
    private void OnDisable()
    {
        inputReader.attackEvent -= Shoot;
    }

    private void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(aimPos.position, aimPos.forward,out hit, range);
        if (hit.transform == null) return;
        if(hit.transform.TryGetComponent(out HealthBehaviour healthBehaviour))
        {
            healthBehaviour.TakeDamage(pistolDamage);
        }
        Debug.Log(hit.transform.name);
    }
}