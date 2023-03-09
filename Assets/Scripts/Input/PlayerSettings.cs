using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player Setting",menuName ="Game/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{

    [SerializeField] private float horizontalSensitivity = 10f;
    [SerializeField] private float verticalSensitivity = 10f;
    [SerializeField] private bool invertY = false;

    public float HorizontalSensitivity { get => horizontalSensitivity; set => SetHorizontal(value); }
    public float VerticalSensitivity { get => verticalSensitivity; set => SetVertical(value); }
    public bool InvertY { get => invertY; set => SetInvertY(value); }

    private void Awake()
    {
        horizontalSensitivity = PlayerPrefs.GetFloat("HorizontalSensitivity", 10f);
        verticalSensitivity = PlayerPrefs.GetFloat("VerticalSensitivity", 10f);
        invertY = PlayerPrefs.GetInt("InvertY", 0) == 1;
    }
    public void SetHorizontal(float value)
    {
        horizontalSensitivity = value;
        PlayerPrefs.GetFloat("HorizontalSensitivity", 10f);
    }


    public void SetInvertY(bool value)
    {
        invertY = value;
        PlayerPrefs.SetInt("InvertY", value ? 1 : 0);
    }

    public void SetVertical(float value)
    {
        verticalSensitivity = value;
        PlayerPrefs.SetFloat("VerticalSensitivity", 10f);
    }


}
