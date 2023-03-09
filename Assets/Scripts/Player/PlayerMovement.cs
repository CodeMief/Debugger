using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputReader InputReader = default;
    [SerializeField] private StatsSO stats;
    private Vector3 position = new Vector3();
    private new Rigidbody rigidbody;
    private Transform cam;
    void OnEnable()
    {
        InputReader.moveEvent += OnMove;
    }
    void OnDisable()
    {
        InputReader.moveEvent -= OnMove;
    }

    void Start()
    {
        cam = Camera.main.transform;
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 dir = cam.forward * position.z + cam.right * position.x;
        rigidbody.MovePosition(transform.position + dir * stats.MovementSpeed * Time.deltaTime);
    }

    //Event System
    private void OnMove(Vector3 value)
    {
        position = value;
    }
}
