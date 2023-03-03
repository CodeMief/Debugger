using UnityEngine;

public class ColorChangeProperty : DebugPropertyBase
{
    [SerializeField] private Material material;
    private Material defaultMaterial;
    private new Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;
    }

    public override void Activate()
    {
        renderer.material = renderer.material == defaultMaterial ? material : defaultMaterial;
    }

    public override string GetName() => "Change Color";
}
