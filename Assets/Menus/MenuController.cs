using UnityEngine;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    public VisualElement currentMenu;
    public VisualElement escapeMenuElement;
    public VisualElement mainMenuElement;

    private void Start()
    {
        // Show the main menu by default
        mainMenuElement.visible = false;
        escapeMenuElement.visible = false;

        ShowMainMenu();
    }

    private void OnEnable()
    {
        // Get references to the menu elements
        UIDocument uiDocument = GetComponent<UIDocument>();
        
        mainMenuElement = uiDocument.rootVisualElement.Q<VisualElement>("MainMenu");

        escapeMenuElement = uiDocument.rootVisualElement.Q<VisualElement>("EscapeMenu");

/*        // Set the current menu to the main menu
        currentMenu = mainMenuElement;

        // Set up the main menu click events
        Button buttonNewGame = mainMenuElement.Q<Button>("ButtonNewGame");
        Button buttonExitToDesktop = mainMenuElement.Q<Button>("ButtonExitToDesktop");
        Button buttonGameOptions = mainMenuElement.Q<Button>("ButtonGameOptions");

        buttonNewGame.clicked += () => MenuOptionSelector("NewGame");
        buttonExitToDesktop.clicked += () => MenuOptionSelector("ExitToDesktop");
        buttonGameOptions.clicked += () => MenuOptionSelector("GameOptions");

        // Set up the escape menu click events
        Button buttonResumeGame = escapeMenuElement.Q<Button>("ButtonResumeGame");
        Button buttonExitToMainMenu = escapeMenuElement.Q<Button>("ButtonExitToMainMenu");

        buttonResumeGame.clicked += () => MenuOptionSelector("ResumeGame");
        buttonExitToMainMenu.clicked += () => MenuOptionSelector("ExitToMainMenu");*/
    }

    private void Update()
    {
        // Open the escape menu when the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowEscapeMenu();
        }
    }

    public void ShowMainMenu()
    {
        mainMenuElement.visible = true;
        escapeMenuElement.visible = false;
        currentMenu = mainMenuElement;
    }

    public void ShowEscapeMenu()
    {
        escapeMenuElement.visible = true;
        mainMenuElement.visible = false;
        currentMenu = escapeMenuElement;
    }

    /*public void MenuOptionSelector(string input)
    {
        switch (input)
        {
            case "NewGame":
                Debug.Log("Generating New Game / Loading Game");
                break;
            case "ExitToDesktop":
                Debug.Log("Exiting Game");
                break;
            case "ResumeGame":
                ShowMainMenu();
                Debug.Log("Resuming game play");
                break;
            case "GameOptions":
                Debug.Log("Loading game options");
                break;
            case "ExitToMainMenu":
                ShowMainMenu();
                Debug.Log("Exiting game play");
                break;
            default:
                Debug.Log("Default case");
                break;
        }
    }*/
}
