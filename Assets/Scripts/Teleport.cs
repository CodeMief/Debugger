using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform targetDestination;
    [SerializeField] private GameObject player;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject == player)
        {
            player.transform.position = targetDestination.position;
        }
    }
}
