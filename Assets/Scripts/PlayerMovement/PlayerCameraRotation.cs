using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraRotation : MonoBehaviour
{
    private PlayerControls _playerControls;
    private InputAction _mouseAxis;

    [SerializeField] private float _verticalRotationSensibility = 1.5f;
    [SerializeField] private float _horizontalRotationSensibility = 3;
    private Vector2 _rotation;
    private float _horizontalRotation = 0f;
    private float _verticalRotation = 0f;
    [SerializeField] private float _clampRange = 45f;

    private void Awake()
    {
        _playerControls = GetComponent<PlayerControls>();

        _mouseAxis = _playerControls.inputActions.PlayerRotation.MouseAxis;

        _rotation = Camera.main.transform.rotation.eulerAngles;
    }
    private void OnEnable()
    {
        _mouseAxis.performed += MouseAxisPerformed;
        _mouseAxis.canceled += MouseAxisPerformed;
    }
    private void OnDisable()
    {
        _mouseAxis.performed -= MouseAxisPerformed;
        _mouseAxis.canceled -= MouseAxisPerformed;
    }

    void LateUpdate()
    {
        RotationUpdate();
    }

    private void MouseAxisPerformed(InputAction.CallbackContext context)
    {
        _rotation = context.ReadValue<Vector2>();

        if(context.phase == InputActionPhase.Canceled)
        {
            _rotation = Vector2.zero;
        }
    }

    private void RotationUpdate()
    {

        _horizontalRotation += _rotation.x * _horizontalRotationSensibility * Time.smoothDeltaTime;
        _verticalRotation += _rotation.y * _verticalRotationSensibility * Time.smoothDeltaTime;

        _verticalRotation = Mathf.Clamp(_verticalRotation, -_clampRange, _clampRange);

        Camera.main.transform.localRotation = Quaternion.Euler(-_verticalRotation, _horizontalRotation, 0); 
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
    }
}
