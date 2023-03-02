using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputReader InputReader = default;
    [SerializeField] private StatsSO stats;
    private Vector3 position = new Vector3();
    private new Rigidbody rigidbody;

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
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Look();

    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody.MovePosition(transform.position + position * stats.MovementSpeed * Time.deltaTime);
    }
    private void Look()
    {
        if (position != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(position);
        }
    }

    //Event System
    private void OnMove(Vector3 value)
    {
        position = value;
    }
}
