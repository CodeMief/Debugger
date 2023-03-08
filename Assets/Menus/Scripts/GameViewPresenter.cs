using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class GameViewPresenter : MonoBehaviour
{

    private VisualElement _EscapeSettingsView;
    private VisualElement _GameView;
    private GameObject _EscapeMenu;
    public UIDocument _EscapeMenuUI;

    void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _GameView = root.Q("EscapeMenu");
        _EscapeSettingsView = root.Q("EscapeSettingsView");

        // Get UI Document game object
        _EscapeMenu = GameObject.Find("Escape Menu");
        _EscapeMenuUI = _EscapeMenu.GetComponent<UIDocument>();


        
        //SetupEscapeMenu();
        SetupEscapeSettingsMenu();

        DontDestroyOnLoad(_EscapeMenu);

    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            _EscapeMenuUI.enabled = !_EscapeMenuUI.enabled;
        }
    }


    // ----- Start Of The Game -----
    private void SetupEscapeMenu()
    {

        // giving the MainMenu presenter script the location of the StartView UXML file root location.

        // MainMenuPresenter menuPresenter = new MainMenuPresenter(_GameView);
        // menuPresenter.OpenSettings = () => ToggleSettingsMenu(true);

    }

    private void SetupEscapeSettingsMenu()
    {
        // SettingsViewPresenter settingsPresenter = new SettingsViewPresenter(_EscapeSettingsView);
        // settingsPresenter.BackAction = () => ToggleSettingsMenu(false);
    }

    private void ToggleSettingsMenu(bool enable)
    {
        _GameView.Display(!enable);
        _EscapeSettingsView.Display(enable);

    }


}
