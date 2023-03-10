using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public string _FirstLevelScene = "MainMenu";
    public void PlayButtonClicked()
    {
        SceneManager.LoadScene(_FirstLevelScene);
    }
    public void QuitButtonClicked()
    {
        Application.Quit();
        Debug.Log("You are leaving the game.");
    }

}
