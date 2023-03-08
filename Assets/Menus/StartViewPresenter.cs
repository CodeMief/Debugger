using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class StartViewPresenter : MonoBehaviour
{

    private VisualElement _SettingsView;
    private VisualElement _StartView;

    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _StartView = root.Q("MainMenu");
        _SettingsView = root.Q("SettingsView");

        SetupStartMenu();
        SetupSettingsMenu();
    }
    private void SetupStartMenu()
    {
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
        Debug.Log(enable);

    }
}
