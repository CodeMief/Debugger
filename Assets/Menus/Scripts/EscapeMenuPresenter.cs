using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class EscapeMenuPresenter
{
    // - - - - UI Elements - - - -
    public Button buttonResume;
    public Button buttonSettings;
    public Button buttonExitToMainMenu;

    private GameObject escapeMenu;
    public UIDocument escapeMenuUI;


 


    // Initialize UI Elements
    public EscapeMenuPresenter (VisualElement root)
    {
        escapeMenu = GameObject.Find("Escape Menu");
        escapeMenuUI = escapeMenu.GetComponent<UIDocument>();


        buttonResume = root.Q<Button>("ButtonResumeGame");
        buttonSettings = root.Q<Button>("ButtonGameSettings");
        buttonExitToMainMenu = root.Q<Button>("ButtonExitToMainMenu");



        buttonResume.clicked += OnResumeButtonClicked;
        buttonExitToMainMenu.clicked += ExitToMainMenu;
    }

    private void OnResumeButtonClicked ()
    {
   
            Debug.Log("Resuming gameplay.");
            escapeMenuUI.enabled = false;

    }
=
    private void ExitToMainMenu()
    {
        Debug.Log("exiting to main menu.");

    }
    // Resume game 

    // Go to settings

    // Exit the game level





}
