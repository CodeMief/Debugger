using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonPressTest : MonoBehaviour
{
   public InputReader reader;
    public DebugPropertyBase propertiesBase;
    private void OnEnable()
    {
        reader.interactEvent += DoSomething;
    }

    private void DoSomething()
    {
        propertiesBase.Activate();
    }
}
