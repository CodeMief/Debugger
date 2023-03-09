using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDeadZone : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float deadzone = -100f;
    void Update()
    {
        if(transform.position.y < deadzone)
        {
            transform.transform.position = respawnPoint.position;
            transform.transform.rotation = respawnPoint.rotation;
        }
    }
}
