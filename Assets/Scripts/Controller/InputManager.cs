using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Dmpk_TPS
{
    public class InputManager : MonoBehaviour
    {
        public static event Action<bool> Jumping, Crouching, Sprinting, Firing, Reloading;
        public static event Action<Vector2> Move, Mouse;
        public static event Action<float> Zoom;
        public static event Action<float> Switch;
        
        private TPSControls controls;

        private void Awake()
        {
            controls = new TPSControls();
        }

        public void OnEnable()
        {
            if (controls != null)
            {
                controls.Gameplay.Enable();

                controls.Gameplay.Move.performed += context => Move?.Invoke(context.ReadValue<Vector2>());
                controls.Gameplay.Move.canceled += context => Move?.Invoke(context.ReadValue<Vector2>());
                controls.Gameplay.Crouch.performed += context => Crouching?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Crouch.canceled += context => Crouching?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Sprint.performed += context => Sprinting?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Sprint.canceled += context => Sprinting?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Jump.performed += context => Jumping?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Jump.canceled += context => Jumping?.Invoke(context.ReadValueAsButton());

                controls.Gameplay.Zoom.performed += context => Zoom?.Invoke(context.ReadValue<Vector2>().y);
                controls.Gameplay.Look.started += context => Mouse?.Invoke(context.ReadValue<Vector2>());
                controls.Gameplay.Look.canceled += context => Mouse?.Invoke(context.ReadValue<Vector2>());

                controls.Gameplay.Weapon1.performed += context => Switch?.Invoke(context.ReadValue<float>());
                controls.Gameplay.Fire1.performed += context => Firing?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Fire1.canceled += context => Firing?.Invoke(context.ReadValueAsButton());
                controls.Gameplay.Reload.performed += context => Reloading?.Invoke(context.ReadValueAsButton());
            }
        }

    }
}
