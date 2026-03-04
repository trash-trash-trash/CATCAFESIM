using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public PlayerInputActions inputActions;

    public event Action<bool> AnnounceEscapeHit;
    public event Action<bool> AnnounceLeftClick;
    public event Action<bool> AnnounceRightClick;

    void Awake()
    {
        inputActions = new PlayerInputActions();

        inputActions.InGameActionMap.Escape.performed += EscapeInput;
        inputActions.InGameActionMap.Escape.canceled += EscapeInput;

        inputActions.InGameActionMap.LeftClick.performed += LeftClickInput;
        inputActions.InGameActionMap.LeftClick.canceled += LeftClickInput;

        inputActions.InGameActionMap.RightClick.performed += RightClickInput;
        inputActions.InGameActionMap.RightClick.canceled += RightClickInput;

        inputActions.Enable();
    }

    private void EscapeInput(InputAction.CallbackContext obj)
    {
        if (obj.performed)
            AnnounceEscapeHit?.Invoke(true);
        else
            AnnounceEscapeHit?.Invoke(false);
    }


    private void LeftClickInput(InputAction.CallbackContext obj)
    {
        if (obj.performed)
            AnnounceLeftClick?.Invoke(true);
        else
            AnnounceLeftClick?.Invoke(false);
    }

    private void RightClickInput(InputAction.CallbackContext obj)
    {
        if (obj.performed)
            AnnounceRightClick?.Invoke(true);
        else
            AnnounceRightClick?.Invoke(false);
    }

    void OnDisable()
    {
        inputActions.InGameActionMap.Escape.performed -= EscapeInput;
        inputActions.InGameActionMap.Escape.canceled -= EscapeInput;
        inputActions.InGameActionMap.LeftClick.performed -= LeftClickInput;
        inputActions.InGameActionMap.LeftClick.canceled -= LeftClickInput;
        inputActions.InGameActionMap.RightClick.performed -= RightClickInput;
        inputActions.InGameActionMap.RightClick.canceled -= RightClickInput;
    }
}