using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions, GameInput.IUIActions, GameInput.IDebuggerToolActions
{
    public event UnityAction<Vector3> moveEvent;
    public event UnityAction attackEvent;
    public event UnityAction interactEvent;
    public event UnityAction reloadEvent;
    public event UnityAction exitDebuggerToolEvent;
    public event UnityAction jumpEvent;
    public GameInput gameInput { get; private set; }
    public event UnityAction<Vector2> lookEvent;
    public event UnityAction escapeEvent;
    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
        }
        EnableGameplay();
    }


    private void OnDisable()
    {
        DisableGameplay();
    }


    private void DisableGameplay() => gameInput.Gameplay.Disable();
    private void DisableUI() => gameInput.UI.Disable();
    private void DisableDebuggerTool() => gameInput.DebuggerTool.Disable();

    public void EnableGameplay()
    {
        gameInput.Gameplay.Enable();
        gameInput.Gameplay.SetCallbacks(this);
        DisableUI();
        DisableDebuggerTool();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void EnableUI()
    {
        gameInput.UI.Enable();
        gameInput.UI.SetCallbacks(this);
        DisableGameplay();
        DisableDebuggerTool();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void EnableDebuggerTool()
    {
        gameInput.DebuggerTool.Enable();
        gameInput.DebuggerTool.SetCallbacks(this);
        DisableGameplay();
        DisableUI();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }


    public void OnMove(InputAction.CallbackContext context)
    {
        moveEvent?.Invoke(context.ReadValue<Vector3>());
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            attackEvent?.Invoke();
        }
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            interactEvent?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            jumpEvent?.Invoke();
        }
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookEvent?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnEscape(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            escapeEvent?.Invoke();
        }
    }

    public void OnSwitchMaps(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (gameInput.Gameplay.enabled)
            {
                Debug.Log("Gameplay off");
                EnableUI();
            }
            else
            {
                Debug.Log("UI off");
                EnableGameplay();
            }
        }
    }

    public void OnExitDebuggerTool(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            exitDebuggerToolEvent?.Invoke();
        }
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            reloadEvent?.Invoke();
        }
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
    }

    public void OnClick(InputAction.CallbackContext context)
    {
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
    }
}
