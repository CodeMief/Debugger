using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollect : MonoBehaviour
{
    [SerializeField] InputReader inputReader = default;
    [SerializeField] GameObject uiDoc;

    [SerializeField] Transform aimPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        inputReader.interactEvent += Interact;
    }

    private void OnDisable()
    {
        inputReader.interactEvent -= Interact;
    }

    private void Interact()
    {
        RaycastHit hit;
        Physics.Raycast(aimPos.position, aimPos.forward, out hit, 10);
        if (hit.transform == null) return;
        if (hit.transform.tag == "DebugDisplay")
        {
            uiDoc.SetActive(true);
            Destroy(hit.transform.gameObject);
        }
    }
}
