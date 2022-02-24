// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controller/Misc/TPSControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Dmpk_TPS
{
    public class @TPSControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @TPSControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""TPSControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""c4622399-2b8f-474c-8e56-ba6e6c142d41"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""109073f2-f100-4298-b10c-d9698dd588cc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a19c752a-ef04-4a3d-a29b-0db736956d73"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""c73a00c1-a175-4b47-8a76-7b1abd3a3fec"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""44245d25-7359-438a-ae6d-c66e947db0a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""9663cc89-f036-4aa7-be9c-c3ebc658b26c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire1"",
                    ""type"": ""Button"",
                    ""id"": ""b3eb8077-86d9-4c32-a445-ae46affb2194"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Value"",
                    ""id"": ""ee14a22d-520b-42fe-ad47-f71573525afc"",
                    ""expectedControlType"": ""Integer"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d64607be-c5c0-48fd-a4fb-c5e7c57d20b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""bd985914-1e22-4a3f-99c7-011aae13194e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire2"",
                    ""type"": ""Button"",
                    ""id"": ""aab22420-d188-4173-8e6b-5684583fee69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""c34f10e7-1bef-494b-b18a-7021347cc32d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7803c02f-824b-40ad-beb8-10a4c0ef0907"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2,InvertVector2(invertX=false)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Move"",
                    ""id"": ""0e43618d-e9cb-428c-82eb-1917db2870a0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5a509d4b-9703-4ecd-af05-cbd2b65932e5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""90a00308-4443-4a37-a1e9-376cbb890602"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5f9fb4e9-bfc1-4694-9283-40b956013174"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0a3a3aa7-c734-435a-829e-11313d713ffa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6645a9fc-e668-4adc-af8d-470008f1b9b8"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ea6d30e-e812-4c8a-952a-82df5fba3e6a"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33f2dca6-2909-44cb-a37d-9d0a8f292d90"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eaf7f1da-8b48-4d21-9b1e-347325aff546"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cce3cd4-d4f1-4a0e-8343-17d9e7cc46df"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9862a1f1-1e06-48f8-ab50-7c5b36a93aca"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e25e480-5edd-4a2f-9565-6dfc3abf39b6"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38b4f432-3c5f-49f2-8c81-f34c14893e4d"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0095086-e0b6-45d1-a399-b96e3e6c2bdd"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35122f04-dd21-4968-a353-a4559f50eea3"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9f3b7a8-43fb-4ab5-a213-952a5d468f1c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0011e0ec-c2b8-4667-a3fe-2180cf9ac215"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
            m_Gameplay_Look = m_Gameplay.FindAction("Look", throwIfNotFound: true);
            m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
            m_Gameplay_Zoom = m_Gameplay.FindAction("Zoom", throwIfNotFound: true);
            m_Gameplay_Crouch = m_Gameplay.FindAction("Crouch", throwIfNotFound: true);
            m_Gameplay_Sprint = m_Gameplay.FindAction("Sprint", throwIfNotFound: true);
            m_Gameplay_Fire1 = m_Gameplay.FindAction("Fire1", throwIfNotFound: true);
            m_Gameplay_Switch = m_Gameplay.FindAction("Switch", throwIfNotFound: true);
            m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
            m_Gameplay_Reload = m_Gameplay.FindAction("Reload", throwIfNotFound: true);
            m_Gameplay_Fire2 = m_Gameplay.FindAction("Fire2", throwIfNotFound: true);
            m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
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

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private IGameplayActions m_GameplayActionsCallbackInterface;
        private readonly InputAction m_Gameplay_Look;
        private readonly InputAction m_Gameplay_Move;
        private readonly InputAction m_Gameplay_Zoom;
        private readonly InputAction m_Gameplay_Crouch;
        private readonly InputAction m_Gameplay_Sprint;
        private readonly InputAction m_Gameplay_Fire1;
        private readonly InputAction m_Gameplay_Switch;
        private readonly InputAction m_Gameplay_Jump;
        private readonly InputAction m_Gameplay_Reload;
        private readonly InputAction m_Gameplay_Fire2;
        private readonly InputAction m_Gameplay_Interact;
        public struct GameplayActions
        {
            private @TPSControls m_Wrapper;
            public GameplayActions(@TPSControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Look => m_Wrapper.m_Gameplay_Look;
            public InputAction @Move => m_Wrapper.m_Gameplay_Move;
            public InputAction @Zoom => m_Wrapper.m_Gameplay_Zoom;
            public InputAction @Crouch => m_Wrapper.m_Gameplay_Crouch;
            public InputAction @Sprint => m_Wrapper.m_Gameplay_Sprint;
            public InputAction @Fire1 => m_Wrapper.m_Gameplay_Fire1;
            public InputAction @Switch => m_Wrapper.m_Gameplay_Switch;
            public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
            public InputAction @Reload => m_Wrapper.m_Gameplay_Reload;
            public InputAction @Fire2 => m_Wrapper.m_Gameplay_Fire2;
            public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    @Look.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                    @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    @Zoom.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoom;
                    @Zoom.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoom;
                    @Zoom.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoom;
                    @Crouch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                    @Crouch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                    @Crouch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                    @Sprint.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                    @Sprint.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                    @Sprint.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                    @Fire1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire1;
                    @Fire1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire1;
                    @Fire1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire1;
                    @Switch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitch;
                    @Switch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitch;
                    @Switch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitch;
                    @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    @Reload.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                    @Reload.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                    @Reload.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                    @Fire2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire2;
                    @Fire2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire2;
                    @Fire2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire2;
                    @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Zoom.started += instance.OnZoom;
                    @Zoom.performed += instance.OnZoom;
                    @Zoom.canceled += instance.OnZoom;
                    @Crouch.started += instance.OnCrouch;
                    @Crouch.performed += instance.OnCrouch;
                    @Crouch.canceled += instance.OnCrouch;
                    @Sprint.started += instance.OnSprint;
                    @Sprint.performed += instance.OnSprint;
                    @Sprint.canceled += instance.OnSprint;
                    @Fire1.started += instance.OnFire1;
                    @Fire1.performed += instance.OnFire1;
                    @Fire1.canceled += instance.OnFire1;
                    @Switch.started += instance.OnSwitch;
                    @Switch.performed += instance.OnSwitch;
                    @Switch.canceled += instance.OnSwitch;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Reload.started += instance.OnReload;
                    @Reload.performed += instance.OnReload;
                    @Reload.canceled += instance.OnReload;
                    @Fire2.started += instance.OnFire2;
                    @Fire2.performed += instance.OnFire2;
                    @Fire2.canceled += instance.OnFire2;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                }
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);
        public interface IGameplayActions
        {
            void OnLook(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnZoom(InputAction.CallbackContext context);
            void OnCrouch(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnFire1(InputAction.CallbackContext context);
            void OnSwitch(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnReload(InputAction.CallbackContext context);
            void OnFire2(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
        }
    }
}
