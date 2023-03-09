using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] PlayerSettings ps;

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
