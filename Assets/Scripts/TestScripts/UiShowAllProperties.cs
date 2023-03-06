using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiShowAllProperties : MonoBehaviour
{
    [SerializeField] private InteractBehaviour interactBehaviour;
    [SerializeField] private GameObject togglePrefab;

    void Start()
    {
        CreateUI(interactBehaviour.GetNames());
    }

    private void CreateUI(string[] names)
    {
        Vector3 spacing = new Vector3(0, 0, 0);
        foreach (string name in names)
        {
            CreateToggleGameObject(name, spacing);
            spacing = new Vector3(spacing.x, spacing.y - 20, spacing.z);
        }
    }

    private void CreateToggleGameObject(string name, Vector3 spacing)
    {
        Toggle toggle = Instantiate(togglePrefab, transform).GetComponent<Toggle>();
        toggle.transform.localPosition += spacing;
        SetToggleProperties(name, toggle);
    }
        
    private void SetToggleProperties(string name, Toggle toggle)
    {
        toggle.isOn = interactBehaviour.GetPropertyState(name);
        toggle.onValueChanged.AddListener(delegate { interactBehaviour.ActivateProperty(name); });
        toggle.gameObject.GetComponentInChildren<Text>().text = name;
    }
}
