using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _force = 100;
    [SerializeField] private float _rotationSensibility = 3;
    [SerializeField] private float _verticalRotationSensibility = 1.5f;
    [SerializeField] private float _horizontalRotationSensibility = 3;
    private Camera _mainCamera;
    private InputActionSystem inputActions;
    private Rigidbody _rigidBody;
    private Vector3 _direction;
    private Vector2 _rotation;
    private float _horizontalRotation = 0f;
    private float _verticalRotation = 0f;

    [SerializeField] private int _maxCollisionDetection = 10;

    [SerializeField] private float _clampRange = 45f;

    [SerializeField] private bool _grounded = false;
    [SerializeField] private float gravity = -20f;

    private void Awake()
    {
        inputActions = new InputActionSystem();

        inputActions.PlayerRotation.MouseAxis.performed += MouseAxisPerformed;
        inputActions.PlayerRotation.MouseAxis.canceled += MouseAxisPerformed;

        inputActions.PlayerMovementVector.Movement.performed += VectorMovementPerformed;
        // inputActions.PlayerMovementVector.Movement.canceled += VectorMovementCanceled;

        inputActions.Enable();

        _rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _mainCamera = Camera.main;
        _rotation = _mainCamera.transform.rotation.eulerAngles;

    }

    private void MouseAxisPerformed(InputAction.CallbackContext context)
    {
        _rotation = context.ReadValue<Vector2>();

        if(context.phase == InputActionPhase.Canceled)
        {
            _rotation = Vector2.zero;
        }
    }

    private void VectorMovementPerformed(InputAction.CallbackContext obj)
    {
        _direction = obj.ReadValue<Vector3>();

        if(_direction == Vector3.zero)
            _rigidBody.velocity = Vector3.zero;
    }

    void Update()
    {
        CameraFollowPlayer();

        _grounded = Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
                                    -transform.up, 
                                    out RaycastHit hitInfo, 
                                    3f, 
                                    LayerMask.GetMask("Ground"));

        if(_grounded)
        {
            Debug.Log("Grounded");
        }
    }

    private void FixedUpdate()
    {
        MovementUpdate();
        GravityScale();
    }

    private void LateUpdate()
    {
        RotationUpdate();
    }

    private void RotationUpdate()
    {

        _horizontalRotation += _rotation.x * _horizontalRotationSensibility * Time.smoothDeltaTime;
        _verticalRotation += _rotation.y * _verticalRotationSensibility * Time.smoothDeltaTime;

        _verticalRotation = Mathf.Clamp(_verticalRotation, -_clampRange, _clampRange);

        _mainCamera.transform.localRotation = Quaternion.Euler(-_verticalRotation, _horizontalRotation, 0); 
        transform.rotation = Quaternion.Euler(0, _mainCamera.transform.rotation.eulerAngles.y, 0);
    }

    private void MovementUpdate()
    {
        var moveDirection = 
            math.normalizesafe(transform.forward) * _direction.z 
            + math.normalizesafe(transform.right) * _direction.x;

        _rigidBody.velocity = math.normalizesafe(moveDirection) * Time.fixedDeltaTime * _force;
    }

    private void CameraFollowPlayer()
    {
        _mainCamera.transform.position = 
            new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
    }

    private void GravityScale()
    {
         _rigidBody.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }

    private RaycastHit[] RaycastNonAlloc(int maxCollisions = 10)
    {
        RaycastHit[] hits = new RaycastHit[maxCollisions];
        Physics.RaycastNonAlloc(_mainCamera.transform.position, _mainCamera.transform.forward, hits, 1000, LayerMask.GetMask("Default"));

        foreach(var hit in hits)
        {
            // if(hit.collider) Debug.Log("NON ALLOC: " + hit.collider.gameObject.name);
        }

        return hits;
    }

    private RaycastHit[] RaycastAlloc()
    {
        RaycastHit[] hits = Physics.RaycastAll(_mainCamera.transform.position, _mainCamera.transform.forward, 1000, LayerMask.GetMask("Default"));
        
        // foreach(var hit in hits)
        // {
        //     if(hit.collider)
        //     {
        //         if(hit.collider.gameObject.TryGetComponent(out IDamageable damageable))
        //         {
        //             damageable.TakeDamage(1);
        //         }

        //         Debug.Log("ALLOC: " + hit.collider.gameObject.name);
        //     }
        // }
        return hits;
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


