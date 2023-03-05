using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveableProperty : DebugPropertyBase
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override string GetName() => "Moveable";
    public override void Activate()
    {
        rb.isKinematic = !rb.isKinematic;
    }

    public override bool GetPropertyState()
    {
        return !rb.isKinematic;
    }
}
