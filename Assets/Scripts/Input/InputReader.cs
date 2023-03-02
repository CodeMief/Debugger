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

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
            gameInput.Gameplay.SetCallbacks(this);

        }
        gameInput.Gameplay.Enable();
    }

    private void OnDisable()
    {
        gameInput.Gameplay.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveEvent?.Invoke(context.ReadValue<Vector3>());
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        attackEvent?.Invoke();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            interactEvent?.Invoke();
        }
    }
}
