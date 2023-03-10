using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    [SerializeField] PlayerSettings ps;
    [SerializeField] InputReader inputReader;
    [SerializeField] Toggle invertY;

    private void Start()
    {
        inputReader.EnableUI();
        invertY.isOn = ps.InvertY;
    }
    private void ConvertToResolution(string text, bool isFullScreen)
    {
        string[] resolutions = text.Split("x");
        Screen.SetResolution(int.Parse(resolutions[0].Trim()), int.Parse(resolutions[1].Trim()), isFullScreen);
    }
    public void ToggleResolution(int arr)
    {
        string text = resolutionDropdown.options[arr].text;
        ConvertToResolution(text, Screen.fullScreen);
    }


    public void FullscreenToggle(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("test");
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetHorizontal(float horizontal)
    {
        ps.SetHorizontal(horizontal);
    }
    public void SetVertical(float vertical)
    {
        ps.SetVertical(vertical);
    }
    public void InvertY(bool value)
    {
        ps.SetInvertY(value);
    }

}
