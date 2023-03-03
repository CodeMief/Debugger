using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionProperty : DebugPropertyBase
{
    private Collider col;
    private void Start()
    {
        col = GetComponent<Collider>();
    }
    public override void Activate()
    {
        col.enabled = !col.enabled;
    }

    public override string GetName() => "Collision";
}
