using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenuPresenter
{
    // - - - - UI Elements - - - -
    public Button _ButtonResume;
    public Button _ButtonSettings;
    public Button _ButtonExitToMainMenu;

    private GameObject _EscapeMenu;
    public UIDocument _EscapeMenuUI;

    // Initialize UI Elements
    public EscapeMenuPresenter (VisualElement root)
    {
        _ButtonResume = root.Q<Button>("ButtonResumeGame");
        _ButtonSettings = root.Q<Button>("ButtonGameSettings");
        _ButtonExitToMainMenu = root.Q<Button>("ButtonExitToMainMenu");

        _EscapeMenu = GameObject.Find("Escape Menu");
        _EscapeMenuUI = _EscapeMenu.GetComponent<UIDocument>();
        
        EscapeMenuOptions();

    }

    private void EscapeMenuOptions()
    {
        _ButtonResume.clicked += () =>
        {

        };
    }
    // Resume game 

    // Go to settings

    // Exit the game level





}
