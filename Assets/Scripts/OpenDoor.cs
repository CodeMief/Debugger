using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] float speed = 1.0f;

    private bool isOpen;

    private void Start()
    {
        isOpen = false;
    }

    private void Update()
    {
        DoorOpenMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        isOpen = true;
        Debug.Log("Triggered");
    }

    private void DoorOpenMovement()
    {
        if (isOpen)
        {
            if (Door.transform.position != targetPosition)
            {
                var step = speed * Time.deltaTime;
                Door.transform.position = Vector3.MoveTowards(Door.transform.position, targetPosition, step);
                Debug.Log("Opening door");
            }
        }
    }
}
