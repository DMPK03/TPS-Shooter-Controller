using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Dmpk_TPS
{
    public class InputManager : MonoBehaviour
    {
        public static event Action<bool> Jumping, Crouching, Sprinting, Firing, Reloading, Interact, Esc;
        public static event Action<Vector2> Move;
        public static event Action<float> Zoom;
        public static event Action<float> Switch;
        public static event Action Drop, Aiming;
        
        private TPSControls controls;
        private bool uiMode;

        private void Awake()
        {
            controls = new TPSControls();
        }

        public void OnEnable()
        {
            if (controls != null)
            {
                controls.Gameplay.Enable();
                controls.Ui.Enable();

                controls.Gameplay.Move.performed += context => Move?.Invoke(context.ReadValue<Vector2>());
                controls.Gameplay.Move.canceled += context => Move?.Invoke(context.ReadValue<Vector2>());
                controls.Gameplay.Crouch.performed += context => Crouching?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Crouch.canceled += context => Crouching?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Sprint.performed += context => Sprinting?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Sprint.canceled += context => Sprinting?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Jump.performed += context => Jumping?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Jump.canceled += context => Jumping?.Invoke(context.ReadValueAsButton());

                controls.Gameplay.Zoom.performed += context => Zoom?.Invoke(context.ReadValue<Vector2>().y);

                controls.Gameplay.Switch.performed += context => Switch?.Invoke(context.ReadValue<float>());
                controls.Gameplay.Fire1.performed += context => Firing?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Fire1.canceled += context => Firing?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Reload.performed += context => Reloading?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Fire2.performed += context => Aiming?.Invoke();
                
                controls.Gameplay.Drop.started += ctx => Drop?.Invoke();

                controls.Gameplay.Interact.performed += context => Interact?.Invoke(context.ReadValueAsButton());

                controls.Ui.Escape.performed += OnEscape;
            }
        }

        private void OnEscape(InputAction.CallbackContext context)
        {
            uiMode = !uiMode;
            Esc?.Invoke(uiMode);

            if(uiMode)
            {
                controls.Gameplay.Disable();
            }
            else
            controls.Gameplay.Enable();
            
        }
    }
}
