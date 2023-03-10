using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private SceneLoader scenemanager;
    // Start is called before the first frame update
    void Start()
    {
        scenemanager = GameObject.FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        scenemanager.LoadScene();
    }
}
