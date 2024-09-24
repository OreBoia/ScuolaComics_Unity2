using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerControlsManager : MonoBehaviour, InputActionSystem.IPlayerMovementVectorActions
{
    private InputActionSystem _inputActions;

    public static UnityAction<InputAction.CallbackContext> handleJump;
    
    void Awake()
    {
        
        _inputActions = new InputActionSystem();

        //SetCallbacks(this); collega lo script al InputAction ( InputActionSystem )
        _inputActions.PlayerMovementVector.SetCallbacks(this);

        _inputActions.PlayerMovementVector.Enable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // if(context.phase == InputActionPhase.Performed
        //     || context.performed)
        // {
        //     Debug.Log("Jump");
        // }

        handleJump?.Invoke(context);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
