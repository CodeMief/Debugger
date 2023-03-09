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
        col.isTrigger = !col.isTrigger;
    }

    public override string GetName() => "Collision";

    public override bool GetPropertyState()
    {
       return !col.isTrigger;
    }
}
