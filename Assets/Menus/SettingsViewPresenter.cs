using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsViewPresenter
{
    // Allows you to add functionality to the return button from outside this script.
    public Action BackAction { set => returnButton.clicked += value; }

    public Button returnButton;
    public Button fullScreenToggle;
    public Button resolutionDropdown;




    // Start is called before the first frame update
    public SettingsViewPresenter(VisualElement root)
    {
        returnButton = root.Q<Button>("ReturnButton");
/*        fullScreenToggle = root.Q<Button>("FullScreenToggle");
        resolutionDropdown = root.Q<Button>("ResolutionDropdown");*/

        AddLogsToButtons();
    }

    private void AddLogsToButtons()
    {
        returnButton.clicked += () => Debug.Log("Returning to main menu.");
/*        fullScreenToggle.clicked += () => Debug.Log("You are toggling full screen mode.");
        resolutionDropdown.clicked += () => Debug.Log("You are opening the resolution settings of the game.");*/
    }
}
