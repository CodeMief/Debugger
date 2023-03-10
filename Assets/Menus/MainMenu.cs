using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _FirstLevelScene = "MainMenu";
    [SerializeField] private InputReader inputReader;
    public void PlayButtonClicked()
    {
        inputReader.EnableGameplay();
        SceneManager.LoadScene(_FirstLevelScene);
    }
    public void QuitButtonClicked()
    {
        Application.Quit();
        Debug.Log("You are leaving the game.");
    }

}
