using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions
{
    public event UnityAction<Vector3> moveEvent;
    public event UnityAction attackEvent;
    public event UnityAction interactEvent;
    public GameInput gameInput;
    public event UnityAction<Vector2> lookEvent;

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
            gameInput.Gameplay.SetCallbacks(this);
        }
        EnableGameplay();
    }

    
    private void OnDisable()
    {
        DisableGameplay();
    }

    private void DisableGameplay()
    {
        gameInput.Gameplay.Disable();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void EnableGameplay()
    {
        gameInput.Gameplay.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
    public void OnLook(InputAction.CallbackContext context)
    {
        lookEvent?.Invoke(context.ReadValue<Vector2>());
    }
}
