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
        Vector3 localPosition = transform.TransformDirection(position);
        transform.rotation = new Quaternion(transform.rotation.x, cam.rotation.y,transform.rotation.z, transform.rotation.w);
        rigidbody.MovePosition(transform.position + localPosition * stats.MovementSpeed * Time.deltaTime);
    }

    //Event System
    private void OnMove(Vector3 value)
    {
        position = value;
    }
}
