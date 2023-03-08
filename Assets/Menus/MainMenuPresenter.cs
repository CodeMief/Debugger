using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuPresenter
{
    // Allows you to add functionality to the settings button from outside this script.
    public Action OpenSettings { set => buttonGameSettings.clicked += value; }

    public Button buttonStartGame;
    public Button buttonExitToDesktop;
    public Button buttonGameSettings;
    


    // Start is called before the first frame update
    public MainMenuPresenter(VisualElement root)
    {
        buttonStartGame = root.Q<Button>("ButtonStartGame");
        buttonExitToDesktop = root.Q<Button>("ButtonExitToDesktop");
        buttonGameSettings = root.Q<Button>("ButtonGameSettings");


        AddLogsToButtons();
    }

    private void AddLogsToButtons()
    {
        buttonStartGame.clicked += () => Debug.Log("You are loading the game.");
        buttonExitToDesktop.clicked += () => Debug.Log("You are leaving the game.");
        buttonGameSettings.clicked += () => Debug.Log("You are opening the settings of the game.");
    }

    // - - - - - Usable functionalities - - - - - -

    // [SerializeField] int startingLevel = 2;
    // SceneManager.LoadScene(startingLevel);

    // Application.Quit();

}
