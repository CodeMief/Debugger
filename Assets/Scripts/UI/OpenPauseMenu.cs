using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPauseMenu : MonoBehaviour
{
    [SerializeField] InputReader inputReader;
    [SerializeField] GameObject pauseMenu;

    private void OnEnable()
    {
        inputReader.escapeEvent += Escape;
    }
    private void OnDisable()
    {
        inputReader.escapeEvent -= Escape;
    }
    private void Escape()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

}
