using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour
{
    Dictionary<string, DebugPropertiesBase> properties;
    void Start()
    {
        GetDebugProperties();
    }
    private void GetDebugProperties()
    {
        properties = new Dictionary<string, DebugPropertiesBase>();
        DebugPropertiesBase[] debugs = gameObject.GetComponents<DebugPropertiesBase>();
        foreach (DebugPropertiesBase property in debugs)
        {
            properties.Add(property.GetName(), property);
            Debug.Log(property.GetName()); //TODO: Debug Only. Remove before commit
        }
    }

    public string[] GetNames()
    {
        List<string> names = new();
        foreach(string name in properties.Keys)
        {
            names.Add(name);
        }
        return names.ToArray();
    }
    public void ActivateProperty(string name)
    {
        properties[name].Activate();
    }
}
