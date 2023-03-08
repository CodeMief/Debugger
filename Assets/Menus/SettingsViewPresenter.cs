using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SettingsViewPresenter : MonoBehaviour
{
    public Button returnButton;
    public Button fullScreenToggle;
    public Button resolutionDropdown;
    public Action BackAction { set => returnButton.clicked += value; }


    // Start is called before the first frame update
    void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        returnButton = root.Q<Button>("ReturnButton");
        fullScreenToggle = root.Q<Button>("FullScreenToggle");
        resolutionDropdown = root.Q<Button>("ResolutionDropdown");

        AddLogsToButtons();
    }

    private void AddLogsToButtons()
    {
        returnButton.clicked += () => Debug.Log("Returning to main menu.");
        fullScreenToggle.clicked += () => Debug.Log("You are toggling full screen mode.");
        resolutionDropdown.clicked += () => Debug.Log("You are opening the resolution settings of the game.");
    }
}
