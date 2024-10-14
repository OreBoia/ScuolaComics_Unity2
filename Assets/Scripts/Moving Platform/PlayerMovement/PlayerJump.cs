using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private PlayerControls _controls { get; set; }
    private Rigidbody _rigidBody;

    private InputAction _jumpAction;
    private CheckGround _checkGround;

    [SerializeField] private float _jumpForce = 10.0f;

    void Awake()
    {
        _controls = GetComponent<PlayerControls>();
        _rigidBody = GetComponent<Rigidbody>();

        _checkGround = GetComponent<CheckGround>();

        _jumpAction = _controls.inputActions.PlayerMovementVector.Jump;
    }

    void OnEnable()
    {
        _jumpAction.performed += PerformJump;
    }

    void OnDisable()
    {
        _jumpAction.performed -= PerformJump;
    }

    private void PerformJump(InputAction.CallbackContext context)
    {
        if(_checkGround.isGrounded) 
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}
