using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour
{
    Dictionary<string, DebugPropertyBase> properties = new();
    void Awake()
    {
        GetDebugProperties(); 
    }
    private void GetDebugProperties()
    {
        properties = new Dictionary<string, DebugPropertyBase>();
        DebugPropertyBase[] debugs = gameObject.GetComponents<DebugPropertyBase>();
        foreach (DebugPropertyBase property in debugs)
        {
            properties.Add(property.GetName(), property);
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
    public bool GetPropertyState(string name)
    {
        return properties[name].GetPropertyState();
    }
}
