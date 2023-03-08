using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsViewPresenter
{
    private List<string> _resolutions = new List<string>()
    {
        "3840x2160",
        "2560x1440",
        "1920x1080",
        "1600x900",
        "1366x768",
        "1280x720"
    };
    
    
    
    // Allows you to add functionality to the return button from outside this script.
    public Action BackAction { set => returnButton.clicked += value; }

    public Button returnButton;
    public Toggle fullScreenToggle;
    public DropdownField resolutionDropdown;




    // Start is called before the first frame update
    public SettingsViewPresenter(VisualElement root)
    {
        returnButton = root.Q<Button>("ReturnButton");
        fullScreenToggle = root.Q<Toggle>("FullScreenToggle");
        resolutionDropdown = root.Q<DropdownField>("ResolutionDropdown");


        // After clicking and releasing the toggle, execute the setfullscreen function, with the true or false value from the fullscreen toggle.
        // Trickledown Trickledown is good practise when you have a complex UI hierarchy and you want from parent to children to execute.
        fullScreenToggle.RegisterCallback<MouseUpEvent>((evt) => { SetFullScreen(fullScreenToggle.value); }, TrickleDown.TrickleDown);
        resolutionDropdown.choices = _resolutions;

        // Change event gives you both the new as the old value
        resolutionDropdown.RegisterValueChangedCallback((value) => SetResolution(value.newValue));

        // Default resolution
        int defaultIndex = _resolutions.IndexOf("1920x1080");
        resolutionDropdown.index = defaultIndex;


        AddLogsToButtons();
    }

    private void SetResolution(string newResolution)
    {

        // Split the list items, removing the x from "width x height".
        string[] resolutionArray = newResolution.Split("x");

        // Turning the list items from string to intergers: width [0] & height [1].
        int[] valuesIntArray = new int[]
        {
            int.Parse(resolutionArray[0]), int.Parse(resolutionArray[1])
        };


        // Sets the resolution to the array values or checks if fullscreen is enabled.
        Screen.SetResolution(valuesIntArray[0], valuesIntArray[1], fullScreenToggle.value);



    }

    private void SetFullScreen(bool enabled)
    {
        Screen.fullScreen = enabled;
    }


    private void AddLogsToButtons()
    {
        returnButton.clicked += () => Debug.Log("Returning to main menu.");
    }
}
