using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class PauseMenu : MonoBehaviour
{
    public static bool _Paused = false;
    public GameObject _PauseMenuCanvas;
    public string _MainMenuScene = "MainMenu";


    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_Paused)
            {
                ResumeGame();
            }
            else
            {
                OpenPauseMenu();
            }
        }
    }

    void OpenPauseMenu()
    {
        _PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        _Paused = true;
        Debug.Log("Testing opening menu.");

    }
    public void ResumeGame()
    {
        _PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1.0f;
        _Paused = false;
        Debug.Log("Testing resuming button.");

    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(_MainMenuScene);
        Debug.Log("Testing main menu button.");

    }

    


} 
