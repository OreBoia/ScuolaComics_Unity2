using System;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 100;
    private PlayerControls _controls;
    private InputAction _movementAction;
    private Rigidbody _rigidBody;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();

        _controls = GetComponent<PlayerControls>();

        _movementAction = _controls.inputActions.PlayerMovementVector.Movement;
    }

    void OnEnable()
    {
        _movementAction.performed += VectorMovementPerformed;
    }

    void OnDisable()
    {
        _movementAction.performed -= VectorMovementPerformed;
    }

    private void VectorMovementPerformed(InputAction.CallbackContext obj)
    {
        _direction = obj.ReadValue<Vector3>();

        if(_direction == Vector3.zero)
            _rigidBody.velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        MovementUpdate();
    }

    private void MovementUpdate()
    {
        var moveDirection = 
            math.normalizesafe(transform.forward) * _direction.z 
            + math.normalizesafe(transform.right) * _direction.x;

        _rigidBody.velocity = math.normalizesafe(moveDirection) * Time.fixedDeltaTime * _speed;
    }

    void OnDrawGizmos()
    {
        // Gizmos.color = new Color(0, 0, 1, 0.5f);
        // Gizmos.DrawSphere(transform.position, 3);

        // Gizmos.color = Color.red;
        // Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 1000);

        // Gizmos.color = Color.blue;
        // Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Vector3.down * 1f);
    }
}


