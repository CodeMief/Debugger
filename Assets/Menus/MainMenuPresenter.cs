using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuPresenter
{
    public Button buttonStartGame;
    public Button buttonExitToDesktop;
    public Button buttonGameSettings;
    [SerializeField] int startingLevel = 2;

    // Allows you to add functionality to that settings button from outside this script
    public Action OpenSettings { set => buttonGameSettings.clicked += value; }

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
        buttonStartGame.clicked += () => SceneManager.LoadScene(startingLevel);
        buttonExitToDesktop.clicked += () => Application.Quit();
        buttonGameSettings.clicked += () => Debug.Log("You are opening the settings of the game.");
    }

}
