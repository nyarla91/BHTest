//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Source/Gameplay/Player/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Regular"",
            ""id"": ""57b5a3ba-adf2-4305-af65-ca3b74a254b4"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""aea07439-0ea4-45c8-8064-f3cdb6af98a2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Charge"",
                    ""type"": ""Button"",
                    ""id"": ""3997c8c8-9a49-4950-849e-4bed66390bb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a6a4d757-c169-4228-ad9a-e8d517c1f79e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f0b72e00-004f-4360-b23e-05a85461937b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""793735ad-5c71-4ad2-8d32-6e8593bcce11"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""85983818-78a4-496a-a8ed-89c43b17d3cb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b9b694ce-34a1-4a29-810c-cd8cf5404859"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""29573032-4855-4368-8848-c1dacb145748"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0e707cee-b187-4278-a2b4-16810c2a1263"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5b8cd84e-17d0-465f-9cd5-7f1a89f4c9d6"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c785dce1-b5b6-42b6-82dd-184ff48886c6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fd2f7c8-d517-4d60-8845-f7d0bd6f2908"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a2f46ae-a4ec-4bd0-8775-2fcb33151519"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5c7d6ba-d17b-468d-9abe-a2227d1b76ec"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30b92487-4477-458e-8474-1a86e0222985"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Always"",
            ""id"": ""4d418db7-3827-4852-a27a-6e2a910ef416"",
            ""actions"": [
                {
                    ""name"": ""CameraOrbit"",
                    ""type"": ""Value"",
                    ""id"": ""fe4c1739-12de-4284-93e8-17e583dba891"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4dfb4227-fe76-4f24-8fc0-994741737c95"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraOrbit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3c3b3b2-d9a6-40c1-9bab-fb9fce9bef78"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraOrbit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Regular
        m_Regular = asset.FindActionMap("Regular", throwIfNotFound: true);
        m_Regular_Movement = m_Regular.FindAction("Movement", throwIfNotFound: true);
        m_Regular_Charge = m_Regular.FindAction("Charge", throwIfNotFound: true);
        m_Regular_Jump = m_Regular.FindAction("Jump", throwIfNotFound: true);
        // Always
        m_Always = asset.FindActionMap("Always", throwIfNotFound: true);
        m_Always_CameraOrbit = m_Always.FindAction("CameraOrbit", throwIfNotFound: true);
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

    // Regular
    private readonly InputActionMap m_Regular;
    private List<IRegularActions> m_RegularActionsCallbackInterfaces = new List<IRegularActions>();
    private readonly InputAction m_Regular_Movement;
    private readonly InputAction m_Regular_Charge;
    private readonly InputAction m_Regular_Jump;
    public struct RegularActions
    {
        private @PlayerInputActions m_Wrapper;
        public RegularActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Regular_Movement;
        public InputAction @Charge => m_Wrapper.m_Regular_Charge;
        public InputAction @Jump => m_Wrapper.m_Regular_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Regular; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RegularActions set) { return set.Get(); }
        public void AddCallbacks(IRegularActions instance)
        {
            if (instance == null || m_Wrapper.m_RegularActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_RegularActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Charge.started += instance.OnCharge;
            @Charge.performed += instance.OnCharge;
            @Charge.canceled += instance.OnCharge;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IRegularActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Charge.started -= instance.OnCharge;
            @Charge.performed -= instance.OnCharge;
            @Charge.canceled -= instance.OnCharge;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IRegularActions instance)
        {
            if (m_Wrapper.m_RegularActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IRegularActions instance)
        {
            foreach (var item in m_Wrapper.m_RegularActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_RegularActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public RegularActions @Regular => new RegularActions(this);

    // Always
    private readonly InputActionMap m_Always;
    private List<IAlwaysActions> m_AlwaysActionsCallbackInterfaces = new List<IAlwaysActions>();
    private readonly InputAction m_Always_CameraOrbit;
    public struct AlwaysActions
    {
        private @PlayerInputActions m_Wrapper;
        public AlwaysActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @CameraOrbit => m_Wrapper.m_Always_CameraOrbit;
        public InputActionMap Get() { return m_Wrapper.m_Always; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AlwaysActions set) { return set.Get(); }
        public void AddCallbacks(IAlwaysActions instance)
        {
            if (instance == null || m_Wrapper.m_AlwaysActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AlwaysActionsCallbackInterfaces.Add(instance);
            @CameraOrbit.started += instance.OnCameraOrbit;
            @CameraOrbit.performed += instance.OnCameraOrbit;
            @CameraOrbit.canceled += instance.OnCameraOrbit;
        }

        private void UnregisterCallbacks(IAlwaysActions instance)
        {
            @CameraOrbit.started -= instance.OnCameraOrbit;
            @CameraOrbit.performed -= instance.OnCameraOrbit;
            @CameraOrbit.canceled -= instance.OnCameraOrbit;
        }

        public void RemoveCallbacks(IAlwaysActions instance)
        {
            if (m_Wrapper.m_AlwaysActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAlwaysActions instance)
        {
            foreach (var item in m_Wrapper.m_AlwaysActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AlwaysActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AlwaysActions @Always => new AlwaysActions(this);
    public interface IRegularActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCharge(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IAlwaysActions
    {
        void OnCameraOrbit(InputAction.CallbackContext context);
    }
}
