using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] InputReader inputReader = default;
    [SerializeField] StatsSO playerStats = default;
    [SerializeField] Transform feetPosition;
    [SerializeField] float groundMAD;
    private new Rigidbody rigidbody;
    private bool canJump = true;
    

    void OnEnable()
    {
        inputReader.jumpEvent += Jump;
    }
    void OnDisable()
    {
        inputReader.jumpEvent -= Jump;
    }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        FloorDetection();

    }
    private void Jump()
    {
        if (canJump)
        {
            rigidbody.AddForce(new Vector3(0, playerStats.JumpHeight, 0), ForceMode.Impulse);
            canJump = false;
            Debug.Log("jump is false");
        }
    }

    private void FloorDetection()
    {
        if (canJump) return;
        if (rigidbody.velocity.y >= 0) return;
        RaycastHit hit;
        Physics.Raycast(feetPosition.position, -feetPosition.up,out hit, 10);
        if (hit.transform == null) return;
        
        if(hit.distance <= groundMAD)
        {
            canJump = true;
            Debug.Log("jump is true");
        }
    }
}
