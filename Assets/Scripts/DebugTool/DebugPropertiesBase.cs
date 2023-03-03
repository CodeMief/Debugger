using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(InteractBehaviour))]
public abstract class DebugPropertiesBase: MonoBehaviour
{
   public abstract void Activate();
    public abstract string GetName();
}
