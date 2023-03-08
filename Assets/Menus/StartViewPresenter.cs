using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class StartViewPresenter : MonoBehaviour
{

    private VisualElement _SettingsView;
    private VisualElement _StartView;

    void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _StartView = root.Q("MainMenu");
        _SettingsView = root.Q("SettingsView");

        SetupStartMenu();
        SetupSettingsMenu();

    }


    // ----- Start Of The Game -----
    private void SetupStartMenu()
    {

        // giving the MainMenu presenter script the location of the StartView UXML file root location.
        MainMenuPresenter menuPresenter = new MainMenuPresenter(_StartView);
        menuPresenter.OpenSettings = () => ToggleSettingsMenu(true);

    }

    private void SetupSettingsMenu()
    {
        SettingsViewPresenter settingsPresenter = new SettingsViewPresenter(_SettingsView);
        settingsPresenter.BackAction = () => ToggleSettingsMenu(false);
    }

    private void ToggleSettingsMenu(bool enable)
    {
        _StartView.Display(!enable);
        _SettingsView.Display(enable);

    }


}
