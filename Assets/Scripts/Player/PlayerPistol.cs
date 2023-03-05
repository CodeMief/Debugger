using UnityEngine;

public class PlayerPistol : MonoBehaviour
{
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
        Debug.Log(hit);
    }
}