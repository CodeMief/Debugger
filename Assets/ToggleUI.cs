using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;



public class ToggleScript : MonoBehaviour
{
    private UIDocument uiDoc;
    [SerializeField] private Transform aimPos;
    [SerializeField] private InputReader reader;
    [SerializeField] private float range = 100f;

    void Update()
    {

    }
    private void Start()
    {
        uiDoc = GetComponent<UIDocument>();
        reader.interactEvent += Interact;
        reader.exitDebuggerToolEvent += ExitDebuggerTool;
    }

    private void ExitDebuggerTool()
    {
        uiDoc.enabled = false;
        reader.EnableGameplay();
    }

    private void OpenUI(InteractBehaviour interactBehaviour)
    {
        uiDoc.enabled = !uiDoc.enabled;
        reader.EnableUI();
    }

    private void Interact()
    {
        RaycastHit hit;
        Physics.Raycast(aimPos.position, aimPos.forward, out hit, range);
        if (hit.transform == null) return;
        if (hit.transform.TryGetComponent(out InteractBehaviour interactBehaviour))
        {
            OpenUI(interactBehaviour);
        }
        Debug.Log(hit.transform.name);
    }
}
