using UnityEngine;
using UnityEngine.UIElements;



public class DebuggerTool : MonoBehaviour
{
    private UIDocument uiDoc;
    [SerializeField] private Transform aimPos;
    [SerializeField] private InputReader reader;
    [SerializeField] private float range = 100f;
    private string elementContainerName = "Elements";
    VisualElement elementContainer;
    [SerializeField] int spacingVal;


    private void OnEnable()
    {

        reader.interactEvent += Interact;
        reader.exitDebuggerToolEvent += ExitDebuggerTool;
    }

    private void OnDisable()
    {
        reader.interactEvent -= Interact;
        reader.exitDebuggerToolEvent -= ExitDebuggerTool;
    }

    private void Start()
    {
        uiDoc = GetComponent<UIDocument>();
        GetContentContainer();
        uiDoc.enabled = false;
    }

    private void GetContentContainer()
    {
        VisualElement element = uiDoc.rootVisualElement[0];
        var children = element.Children();
        foreach (var child in children)
        {
            if (child.name == elementContainerName)
            {
                elementContainer = child;
            }
        }
    }

    void Update()
    {

    }

    private void ExitDebuggerTool()
    {
        uiDoc.enabled = false;
        reader.EnableGameplay();
    }

    private void EnterDebuggerTool()
    {
        uiDoc.enabled = true;
        reader.EnableUI();
    }

    private void Interact()
    {
        RaycastHit hit;
        Physics.Raycast(aimPos.position, aimPos.forward, out hit, range);
        if (hit.transform == null) return;
        if (hit.transform.TryGetComponent(out InteractBehaviour interactBehaviour))
        {
            EnterDebuggerTool();
            CreateUI(interactBehaviour);
        }
    }
    private void CreateUI(InteractBehaviour interactBehaviour)
    {
        GetContentContainer();
        Vector3 spacing = new Vector3(10, -10, 0);

        string[] names = interactBehaviour.GetNames();

        foreach (string name in names)
        {
            CreateToggleGameObject(name, spacing, interactBehaviour);
            spacing = new Vector3(spacing.x, spacing.y + spacingVal, spacing.z);
        }
    }

    private void CreateToggleGameObject(string name, Vector3 spacing, InteractBehaviour interactBehaviour)
    {

        Toggle toggle = new Toggle();
        toggle.name = name;
        toggle.text = name;
        toggle.style.color = Color.white;
        toggle.BringToFront();
        //Add event for callback
        toggle.value = interactBehaviour.GetPropertyState(name);
        toggle.RegisterValueChangedCallback(delegate { interactBehaviour.ActivateProperty(name); });
        toggle.transform.position += spacing;
        elementContainer.Add(toggle);
        if (elementContainer.childCount == 1) toggle.Focus();
    }
}