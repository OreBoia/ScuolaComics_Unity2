using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    private PlayerControlsManager _playerControlsManager;
    void Awake()
    {
        _playerControlsManager = GetComponent<PlayerControlsManager>();
        // _playerControlsManager.OnJump(new InputAction.CallbackContext());
    }

    void OnEnable()
    {
        PlayerControlsManager.handleJump += OnDash;
    }

    void OnDisable()
    {
        PlayerControlsManager.handleJump -= OnDash;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed
            || context.performed)
        {
            Debug.Log("Dash");
        }
    }


}
