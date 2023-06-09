using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(InteractBehaviour))]
public abstract class DebugPropertyBase: MonoBehaviour
{
   public abstract void Activate();
    public abstract string GetName();
    public abstract bool GetPropertyState();
}
