//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/PlayerScripts/PlayerInputs.inputactions
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

public partial class @PlayerInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""9ba990f7-ad41-4624-b71d-f569ed8f7b89"",
            ""actions"": [
                {
                    ""name"": ""PlayerMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""44019ff7-ad8b-4ecf-9bc1-b0eea5be5e0e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""LeftAnalogStick"",
                    ""id"": ""35e8a890-80d8-4c00-90e3-a8e1d80c9259"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""81a6339f-f8b2-4c99-a18b-e52821cad89e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""12a167e2-e0d5-43c6-a20e-47700ddecbb1"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4a96c096-87a8-4dcc-8f47-2bd93ac3e97a"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""66615edb-ca00-4f30-a33a-3055be1f877d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyboardMovement"",
                    ""id"": ""112becc7-4ae3-4160-9343-2b7849e7bd85"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""29ad5611-415a-4651-9566-be30abc1e2ad"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dd90bfa0-f241-417f-90a9-12c5fdc5c8db"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9849ec56-e2cb-4f10-bf94-ea605a7f4106"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""09ea688c-3125-4690-8e14-3d70c01c24ed"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""CameraMovement"",
            ""id"": ""0ba2e3a4-940e-41ef-8733-8612cef99f4a"",
            ""actions"": [
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0d385b2f-09c7-4403-bf4d-78508fc18f4e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""RightAnalogStick"",
                    ""id"": ""9f2dbcfd-8371-4383-a852-dbd8d31f5133"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""771f1335-cb5f-4c9a-9a92-996c0e2b9ff5"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c4016f7a-ee54-432f-83ee-f1ab58cc8b27"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c099590f-b8bd-4c02-acef-425a612732da"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f577df91-df60-4350-aaa5-5fe53c83eef7"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""AttackInputs"",
            ""id"": ""9f9323d8-fa9b-4a38-96ed-75006cf7dc61"",
            ""actions"": [
                {
                    ""name"": ""AttackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""213c8b9e-a74b-47b8-a2b2-8ce4f5f88a7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1f57c36e-6b13-4d12-a0b3-4504ef057a80"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackInputs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InteractionInput"",
            ""id"": ""79855ea7-333d-4dc8-93fe-add1948e5c28"",
            ""actions"": [
                {
                    ""name"": ""InteractionInput"",
                    ""type"": ""Button"",
                    ""id"": ""11fba23a-97b3-498a-831d-960416d3a2c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""21b747e6-3945-4665-8e96-756ee3f39bcf"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractionInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_PlayerMovement = m_PlayerMovement.FindAction("PlayerMovement", throwIfNotFound: true);
        // CameraMovement
        m_CameraMovement = asset.FindActionMap("CameraMovement", throwIfNotFound: true);
        m_CameraMovement_CameraMovement = m_CameraMovement.FindAction("CameraMovement", throwIfNotFound: true);
        // AttackInputs
        m_AttackInputs = asset.FindActionMap("AttackInputs", throwIfNotFound: true);
        m_AttackInputs_AttackInputs = m_AttackInputs.FindAction("AttackInputs", throwIfNotFound: true);
        // InteractionInput
        m_InteractionInput = asset.FindActionMap("InteractionInput", throwIfNotFound: true);
        m_InteractionInput_InteractionInput = m_InteractionInput.FindAction("InteractionInput", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerMovement_PlayerMovement;
    public struct PlayerMovementActions
    {
        private @PlayerInputs m_Wrapper;
        public PlayerMovementActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerMovement => m_Wrapper.m_PlayerMovement_PlayerMovement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Add(instance);
            @PlayerMovement.started += instance.OnPlayerMovement;
            @PlayerMovement.performed += instance.OnPlayerMovement;
            @PlayerMovement.canceled += instance.OnPlayerMovement;
        }

        private void UnregisterCallbacks(IPlayerMovementActions instance)
        {
            @PlayerMovement.started -= instance.OnPlayerMovement;
            @PlayerMovement.performed -= instance.OnPlayerMovement;
            @PlayerMovement.canceled -= instance.OnPlayerMovement;
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

    // CameraMovement
    private readonly InputActionMap m_CameraMovement;
    private List<ICameraMovementActions> m_CameraMovementActionsCallbackInterfaces = new List<ICameraMovementActions>();
    private readonly InputAction m_CameraMovement_CameraMovement;
    public struct CameraMovementActions
    {
        private @PlayerInputs m_Wrapper;
        public CameraMovementActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @CameraMovement => m_Wrapper.m_CameraMovement_CameraMovement;
        public InputActionMap Get() { return m_Wrapper.m_CameraMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraMovementActions set) { return set.Get(); }
        public void AddCallbacks(ICameraMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_CameraMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CameraMovementActionsCallbackInterfaces.Add(instance);
            @CameraMovement.started += instance.OnCameraMovement;
            @CameraMovement.performed += instance.OnCameraMovement;
            @CameraMovement.canceled += instance.OnCameraMovement;
        }

        private void UnregisterCallbacks(ICameraMovementActions instance)
        {
            @CameraMovement.started -= instance.OnCameraMovement;
            @CameraMovement.performed -= instance.OnCameraMovement;
            @CameraMovement.canceled -= instance.OnCameraMovement;
        }

        public void RemoveCallbacks(ICameraMovementActions instance)
        {
            if (m_Wrapper.m_CameraMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICameraMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_CameraMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CameraMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CameraMovementActions @CameraMovement => new CameraMovementActions(this);

    // AttackInputs
    private readonly InputActionMap m_AttackInputs;
    private List<IAttackInputsActions> m_AttackInputsActionsCallbackInterfaces = new List<IAttackInputsActions>();
    private readonly InputAction m_AttackInputs_AttackInputs;
    public struct AttackInputsActions
    {
        private @PlayerInputs m_Wrapper;
        public AttackInputsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @AttackInputs => m_Wrapper.m_AttackInputs_AttackInputs;
        public InputActionMap Get() { return m_Wrapper.m_AttackInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AttackInputsActions set) { return set.Get(); }
        public void AddCallbacks(IAttackInputsActions instance)
        {
            if (instance == null || m_Wrapper.m_AttackInputsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AttackInputsActionsCallbackInterfaces.Add(instance);
            @AttackInputs.started += instance.OnAttackInputs;
            @AttackInputs.performed += instance.OnAttackInputs;
            @AttackInputs.canceled += instance.OnAttackInputs;
        }

        private void UnregisterCallbacks(IAttackInputsActions instance)
        {
            @AttackInputs.started -= instance.OnAttackInputs;
            @AttackInputs.performed -= instance.OnAttackInputs;
            @AttackInputs.canceled -= instance.OnAttackInputs;
        }

        public void RemoveCallbacks(IAttackInputsActions instance)
        {
            if (m_Wrapper.m_AttackInputsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAttackInputsActions instance)
        {
            foreach (var item in m_Wrapper.m_AttackInputsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AttackInputsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AttackInputsActions @AttackInputs => new AttackInputsActions(this);

    // InteractionInput
    private readonly InputActionMap m_InteractionInput;
    private List<IInteractionInputActions> m_InteractionInputActionsCallbackInterfaces = new List<IInteractionInputActions>();
    private readonly InputAction m_InteractionInput_InteractionInput;
    public struct InteractionInputActions
    {
        private @PlayerInputs m_Wrapper;
        public InteractionInputActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @InteractionInput => m_Wrapper.m_InteractionInput_InteractionInput;
        public InputActionMap Get() { return m_Wrapper.m_InteractionInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionInputActions set) { return set.Get(); }
        public void AddCallbacks(IInteractionInputActions instance)
        {
            if (instance == null || m_Wrapper.m_InteractionInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InteractionInputActionsCallbackInterfaces.Add(instance);
            @InteractionInput.started += instance.OnInteractionInput;
            @InteractionInput.performed += instance.OnInteractionInput;
            @InteractionInput.canceled += instance.OnInteractionInput;
        }

        private void UnregisterCallbacks(IInteractionInputActions instance)
        {
            @InteractionInput.started -= instance.OnInteractionInput;
            @InteractionInput.performed -= instance.OnInteractionInput;
            @InteractionInput.canceled -= instance.OnInteractionInput;
        }

        public void RemoveCallbacks(IInteractionInputActions instance)
        {
            if (m_Wrapper.m_InteractionInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInteractionInputActions instance)
        {
            foreach (var item in m_Wrapper.m_InteractionInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InteractionInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InteractionInputActions @InteractionInput => new InteractionInputActions(this);
    public interface IPlayerMovementActions
    {
        void OnPlayerMovement(InputAction.CallbackContext context);
    }
    public interface ICameraMovementActions
    {
        void OnCameraMovement(InputAction.CallbackContext context);
    }
    public interface IAttackInputsActions
    {
        void OnAttackInputs(InputAction.CallbackContext context);
    }
    public interface IInteractionInputActions
    {
        void OnInteractionInput(InputAction.CallbackContext context);
    }
}
