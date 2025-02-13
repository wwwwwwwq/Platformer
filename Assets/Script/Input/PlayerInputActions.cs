//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Settings/Input System/PlayerInputActions.inputactions
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
            ""name"": ""PlayerA"",
            ""id"": ""acd63212-1e26-4783-8ddc-ff5563e6bbee"",
            ""actions"": [
                {
                    ""name"": ""Axes"",
                    ""type"": ""Value"",
                    ""id"": ""04807358-3fe9-42bf-b070-dcf7b4a475d1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d8974910-72b4-4b62-8036-a5dd33231534"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""c891ef0a-4da8-476a-a88a-f032f17463b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD"",
                    ""id"": ""34ceffdc-d2be-479c-9869-8ef477f9f280"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4317414f-2821-46da-ac55-3b0d2047d984"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""78857f15-fe01-4f25-982f-ad579f709ca7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f5627459-7bba-49c3-8e7c-e8c94fd0e2c2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""754aa147-6564-49af-8d72-38793a2b9e25"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerB"",
            ""id"": ""61d19d80-3bc8-46e2-bb47-6bec81a71498"",
            ""actions"": [
                {
                    ""name"": ""Axes"",
                    ""type"": ""Value"",
                    ""id"": ""02159dec-5d7f-40eb-87bf-92cd42c4e66f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4d4760d9-4c42-4e0d-ae4c-9b1f7ecee61b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""518dcd5a-fb75-45b2-8a72-8f1368f0656f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrows"",
                    ""id"": ""9c73a8f6-66d9-459d-8283-569e9096708a"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""36177160-369d-42c8-8da8-f8a77b884ba7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""07c14812-7e81-492a-a5c1-93fd24e1c0c8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""68ff6685-e213-4d47-9703-b58bbfa2fa2a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46bb3266-9c17-4e3d-bd01-19e552c58d46"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerA
        m_PlayerA = asset.FindActionMap("PlayerA", throwIfNotFound: true);
        m_PlayerA_Axes = m_PlayerA.FindAction("Axes", throwIfNotFound: true);
        m_PlayerA_Jump = m_PlayerA.FindAction("Jump", throwIfNotFound: true);
        m_PlayerA_Crouch = m_PlayerA.FindAction("Crouch", throwIfNotFound: true);
        // PlayerB
        m_PlayerB = asset.FindActionMap("PlayerB", throwIfNotFound: true);
        m_PlayerB_Axes = m_PlayerB.FindAction("Axes", throwIfNotFound: true);
        m_PlayerB_Jump = m_PlayerB.FindAction("Jump", throwIfNotFound: true);
        m_PlayerB_Crouch = m_PlayerB.FindAction("Crouch", throwIfNotFound: true);
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

    // PlayerA
    private readonly InputActionMap m_PlayerA;
    private List<IPlayerAActions> m_PlayerAActionsCallbackInterfaces = new List<IPlayerAActions>();
    private readonly InputAction m_PlayerA_Axes;
    private readonly InputAction m_PlayerA_Jump;
    private readonly InputAction m_PlayerA_Crouch;
    public struct PlayerAActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerAActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Axes => m_Wrapper.m_PlayerA_Axes;
        public InputAction @Jump => m_Wrapper.m_PlayerA_Jump;
        public InputAction @Crouch => m_Wrapper.m_PlayerA_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_PlayerA; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerAActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerAActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerAActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerAActionsCallbackInterfaces.Add(instance);
            @Axes.started += instance.OnAxes;
            @Axes.performed += instance.OnAxes;
            @Axes.canceled += instance.OnAxes;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
        }

        private void UnregisterCallbacks(IPlayerAActions instance)
        {
            @Axes.started -= instance.OnAxes;
            @Axes.performed -= instance.OnAxes;
            @Axes.canceled -= instance.OnAxes;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
        }

        public void RemoveCallbacks(IPlayerAActions instance)
        {
            if (m_Wrapper.m_PlayerAActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerAActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerAActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerAActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerAActions @PlayerA => new PlayerAActions(this);

    // PlayerB
    private readonly InputActionMap m_PlayerB;
    private List<IPlayerBActions> m_PlayerBActionsCallbackInterfaces = new List<IPlayerBActions>();
    private readonly InputAction m_PlayerB_Axes;
    private readonly InputAction m_PlayerB_Jump;
    private readonly InputAction m_PlayerB_Crouch;
    public struct PlayerBActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerBActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Axes => m_Wrapper.m_PlayerB_Axes;
        public InputAction @Jump => m_Wrapper.m_PlayerB_Jump;
        public InputAction @Crouch => m_Wrapper.m_PlayerB_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_PlayerB; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerBActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerBActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerBActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerBActionsCallbackInterfaces.Add(instance);
            @Axes.started += instance.OnAxes;
            @Axes.performed += instance.OnAxes;
            @Axes.canceled += instance.OnAxes;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
        }

        private void UnregisterCallbacks(IPlayerBActions instance)
        {
            @Axes.started -= instance.OnAxes;
            @Axes.performed -= instance.OnAxes;
            @Axes.canceled -= instance.OnAxes;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
        }

        public void RemoveCallbacks(IPlayerBActions instance)
        {
            if (m_Wrapper.m_PlayerBActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerBActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerBActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerBActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerBActions @PlayerB => new PlayerBActions(this);
    public interface IPlayerAActions
    {
        void OnAxes(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
    public interface IPlayerBActions
    {
        void OnAxes(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
}
