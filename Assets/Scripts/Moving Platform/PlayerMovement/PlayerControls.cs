using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private InputActionSystem _inputActionSystem;
    public InputActionSystem inputActions{ get { return _inputActionSystem;}}

    private void Awake()
    {   
        _inputActionSystem = new InputActionSystem();
    }

    void OnEnable()
    {
        _inputActionSystem.Enable();
    }

    void OnDisable()
    {
        _inputActionSystem.Disable();
    }
}