//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem/InputActionSystem.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActionSystem: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActionSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActionSystem"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""769f3152-c7d0-4409-be57-718999956b5c"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""5a92a3d0-9bab-4963-8c4a-a9a04a7a6c43"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""9ad9b1a9-4639-40c3-aa52-cddcaac002c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""1f0c1dce-9f35-4232-9a36-f3c1edd10ac6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""89b515bb-af6d-41da-9e80-5768674882a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8b9205fc-eb89-48ff-a2ca-00aa9bae3e47"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd943125-33f1-4dbd-95ae-2dec4880ae14"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47021637-a7fa-432d-b405-7db9fe51909b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""554330aa-0193-4298-ad1b-afa05ab5e0d5"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8524164-c07f-40a7-bf5a-646dd8b1c241"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28318102-815a-4b8f-b660-cf330562ed4a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""892192a7-d9ca-4a86-9120-ac41e88bc9b8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0c661c5-e98e-4bb2-aa5d-78bc6b4146c6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerRotation"",
            ""id"": ""8977b661-9932-4227-89b4-2b5fea08bd90"",
            ""actions"": [
                {
                    ""name"": ""MouseAxis"",
                    ""type"": ""Value"",
                    ""id"": ""20707d88-22f1-4490-abda-c2aab2b91e83"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8b39e60f-42cf-408e-b493-66ad6ab05044"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""MouseAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerMovementVector"",
            ""id"": ""2021ac7b-9b4e-4f94-a149-a6320e3da77a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""8edea99e-befa-4a3e-bff6-5197ec504797"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""dd9441d4-9665-4ba8-a2d1-61617a96361d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""15e02006-ad98-44f8-a6d6-840147b43843"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""219e8598-2c0b-4389-bff6-ba139db42604"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""acb0ef87-d362-4678-b076-d0eeb828aa58"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""321467d8-49ae-4098-8b71-681f801b43da"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""b8747ba4-2439-474b-8218-6129df23854e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""6324a952-dd4e-4ba9-a9c2-211b75f631a0"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""934d53cf-bd5b-40b6-8dc4-8ab8a2a44d01"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c8d4e5ed-dd4c-4ced-a277-a6f9e60bbcd6"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""35906bee-763b-43b2-8afe-de662ac8c69f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""b67081b8-3453-43d0-abed-772e9074d46f"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b806091d-7349-4c3f-8311-a8f5f4c346de"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerShoot"",
            ""id"": ""39608fc2-42b9-47c8-bd2d-6b15e923fee4"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""e0cf93b1-05a6-4287-a2a8-5f572336a23f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ac55b546-8540-4818-b9a0-91e7509f74c5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed7d3287-ba21-4637-ae7b-ecddbccab04f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Forward = m_PlayerMovement.FindAction("Forward", throwIfNotFound: true);
        m_PlayerMovement_Back = m_PlayerMovement.FindAction("Back", throwIfNotFound: true);
        m_PlayerMovement_Left = m_PlayerMovement.FindAction("Left", throwIfNotFound: true);
        m_PlayerMovement_Right = m_PlayerMovement.FindAction("Right", throwIfNotFound: true);
        // PlayerRotation
        m_PlayerRotation = asset.FindActionMap("PlayerRotation", throwIfNotFound: true);
        m_PlayerRotation_MouseAxis = m_PlayerRotation.FindAction("MouseAxis", throwIfNotFound: true);
        // PlayerMovementVector
        m_PlayerMovementVector = asset.FindActionMap("PlayerMovementVector", throwIfNotFound: true);
        m_PlayerMovementVector_Movement = m_PlayerMovementVector.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovementVector_Jump = m_PlayerMovementVector.FindAction("Jump", throwIfNotFound: true);
        // PlayerShoot
        m_PlayerShoot = asset.FindActionMap("PlayerShoot", throwIfNotFound: true);
        m_PlayerShoot_Shoot = m_PlayerShoot.FindAction("Shoot", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private List<IPlayerMovementActions> m_PlayerMovementActionsCallbackInterfaces = new List<IPlayerMovementActions>();
    private readonly InputAction m_PlayerMovement_Forward;
    private readonly InputAction m_PlayerMovement_Back;
    private readonly InputAction m_PlayerMovement_Left;
    private readonly InputAction m_PlayerMovement_Right;
    public struct PlayerMovementActions
    {
        private @InputActionSystem m_Wrapper;
        public PlayerMovementActions(@InputActionSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_PlayerMovement_Forward;
        public InputAction @Back => m_Wrapper.m_PlayerMovement_Back;
        public InputAction @Left => m_Wrapper.m_PlayerMovement_Left;
        public InputAction @Right => m_Wrapper.m_PlayerMovement_Right;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Add(instance);
            @Forward.started += instance.OnForward;
            @Forward.performed += instance.OnForward;
            @Forward.canceled += instance.OnForward;
            @Back.started += instance.OnBack;
            @Back.performed += instance.OnBack;
            @Back.canceled += instance.OnBack;
            @Left.started += instance.OnLeft;
            @Left.performed += instance.OnLeft;
            @Left.canceled += instance.OnLeft;
            @Right.started += instance.OnRight;
            @Right.performed += instance.OnRight;
            @Right.canceled += instance.OnRight;
        }

        private void UnregisterCallbacks(IPlayerMovementActions instance)
        {
            @Forward.started -= instance.OnForward;
            @Forward.performed -= instance.OnForward;
            @Forward.canceled -= instance.OnForward;
            @Back.started -= instance.OnBack;
            @Back.performed -= instance.OnBack;
            @Back.canceled -= instance.OnBack;
            @Left.started -= instance.OnLeft;
            @Left.performed -= instance.OnLeft;
            @Left.canceled -= instance.OnLeft;
            @Right.started -= instance.OnRight;
            @Right.performed -= instance.OnRight;
            @Right.canceled -= instance.OnRight;
        }

        public void RemoveCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // PlayerRotation
    private readonly InputActionMap m_PlayerRotation;
    private List<IPlayerRotationActions> m_PlayerRotationActionsCallbackInterfaces = new List<IPlayerRotationActions>();
    private readonly InputAction m_PlayerRotation_MouseAxis;
    public struct PlayerRotationActions
    {
        private @InputActionSystem m_Wrapper;
        public PlayerRotationActions(@InputActionSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseAxis => m_Wrapper.m_PlayerRotation_MouseAxis;
        public InputActionMap Get() { return m_Wrapper.m_PlayerRotation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerRotationActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerRotationActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerRotationActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerRotationActionsCallbackInterfaces.Add(instance);
            @MouseAxis.started += instance.OnMouseAxis;
            @MouseAxis.performed += instance.OnMouseAxis;
            @MouseAxis.canceled += instance.OnMouseAxis;
        }

        private void UnregisterCallbacks(IPlayerRotationActions instance)
        {
            @MouseAxis.started -= instance.OnMouseAxis;
            @MouseAxis.performed -= instance.OnMouseAxis;
            @MouseAxis.canceled -= instance.OnMouseAxis;
        }

        public void RemoveCallbacks(IPlayerRotationActions instance)
        {
            if (m_Wrapper.m_PlayerRotationActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerRotationActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerRotationActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerRotationActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerRotationActions @PlayerRotation => new PlayerRotationActions(this);

    // PlayerMovementVector
    private readonly InputActionMap m_PlayerMovementVector;
    private List<IPlayerMovementVectorActions> m_PlayerMovementVectorActionsCallbackInterfaces = new List<IPlayerMovementVectorActions>();
    private readonly InputAction m_PlayerMovementVector_Movement;
    private readonly InputAction m_PlayerMovementVector_Jump;
    public struct PlayerMovementVectorActions
    {
        private @InputActionSystem m_Wrapper;
        public PlayerMovementVectorActions(@InputActionSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovementVector_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerMovementVector_Jump;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovementVector; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementVectorActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMovementVectorActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMovementVectorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMovementVectorActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IPlayerMovementVectorActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IPlayerMovementVectorActions instance)
        {
            if (m_Wrapper.m_PlayerMovementVectorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerMovementVectorActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerMovementVectorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerMovementVectorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerMovementVectorActions @PlayerMovementVector => new PlayerMovementVectorActions(this);

    // PlayerShoot
    private readonly InputActionMap m_PlayerShoot;
    private List<IPlayerShootActions> m_PlayerShootActionsCallbackInterfaces = new List<IPlayerShootActions>();
    private readonly InputAction m_PlayerShoot_Shoot;
    public struct PlayerShootActions
    {
        private @InputActionSystem m_Wrapper;
        public PlayerShootActions(@InputActionSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_PlayerShoot_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_PlayerShoot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerShootActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerShootActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerShootActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerShootActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IPlayerShootActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IPlayerShootActions instance)
        {
            if (m_Wrapper.m_PlayerShootActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerShootActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerShootActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerShootActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerShootActions @PlayerShoot => new PlayerShootActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerMovementActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
    public interface IPlayerRotationActions
    {
        void OnMouseAxis(InputAction.CallbackContext context);
    }
    public interface IPlayerMovementVectorActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IPlayerShootActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
}
