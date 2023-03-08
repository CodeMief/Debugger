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



    // Define what the starting level is by looking in the build settings what the index number is OR in this case using a string to write down the scene name.
    [SerializeField] string startingLevel = "StartingLevel";


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
        buttonStartGame.clicked += () =>
        {
            Debug.Log("You are starting the game.");
            SceneManager.LoadScene(startingLevel);
        };
        buttonExitToDesktop.clicked += () =>
        {
            Application.Quit();
            Debug.Log("You are leaving the game.");
        };
        buttonGameSettings.clicked += () => Debug.Log("You are opening the settings of the game.");
    }



}
