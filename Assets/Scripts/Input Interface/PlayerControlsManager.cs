using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerControlsManager : MonoBehaviour, InputActionSystem.IPlayerMovementVectorActions
{
    private InputActionSystem _inputActions;

    public static UnityAction onJump;
    public static UnityAction HandleJump;
    public static UnityAction<string> HandleJumpString;

    public UnityEvent<string> unityEvent;

    public static UnityAction<InputAction.CallbackContext> handleJump;
    
    void Awake()
    {
        
        _inputActions = new InputActionSystem();

        //SetCallbacks(this); collega lo script al InputAction ( InputActionSystem )
        _inputActions.PlayerMovementVector.SetCallbacks(this);

        _inputActions.PlayerMovementVector.Enable();
    }

    void OnEnable()
    {
        HandleJump += FaiQualcosaOnJump;

        // HandleJumpString += FaiQualcosaOnJump;
    }

    void OnDisable()
    {
        HandleJump -= FaiQualcosaOnJump;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // if(context.phase == InputActionPhase.Performed
        //     || context.performed)
        // {
        //     Debug.Log("Jump");
        // }

        handleJump?.Invoke(context);

        HandleJumpString?.Invoke("Ciao");
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    private void FaiQualcosaOnJump()
    {
        Debug.Log("Jump");    
    }

    public void FaiQualcosaOnJump(string stringa, string stringa2)
    {
        Debug.Log(stringa);    
    }
}
