using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIController : MonoBehaviour
{
    public Button buttonStartGame;
    public Button buttonExitToDesktop;
    public Button buttonGameOptions;
    [SerializeField] int startingLevel = 2;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root= GetComponent<UIDocument>().rootVisualElement;
        buttonStartGame = root.Q<Button>("ButtonStartGame");
        buttonExitToDesktop = root.Q<Button>("ButtonExitToDesktop");
        buttonGameOptions = root.Q<Button>("ButtonGameOptions");

        buttonStartGame.clicked += StartButtonPressed;
        buttonExitToDesktop.clicked += ExitButtonClicked;
        buttonGameOptions.clicked += OptionButtonClicked;
    }

    void StartButtonPressed()
    {
       SceneManager.LoadScene(startingLevel);
    }
    void ExitButtonClicked()
    {
        Application.Quit();
    }
    void OptionButtonClicked()
    {
        Debug.Log("Hello World :3");
    }
}
