using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class StartViewPresenter : MonoBehaviour
{

    private VisualElement _SettingsView;
    private VisualElement _StartView;

    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _StartView = root.Q("StartView");
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
        _StartView.Display(true);
        _SettingsView.Display(false);
    }
}
