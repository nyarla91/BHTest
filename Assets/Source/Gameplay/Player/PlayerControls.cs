using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Gameplay.Player
{
    public class PlayerControls : MonoBehaviour
    {
        private PlayerInputActions _inputAction;

        public Vector2 Movement => _inputAction.Regular.Movement.ReadValue<Vector2>();
        public Vector2 CameraOrbit => _inputAction.Always.CameraOrbit.ReadValue<Vector2>();
        
        public event Action JumpPressed;
        public event Action ChargePressed;
        
        private void Awake()
        {
            _inputAction = new PlayerInputActions();
            _inputAction.Enable();
        }

        private void OnEnable()
        {
            _inputAction.Regular.Jump.performed += JumpedPressedInvoke;
            _inputAction.Regular.Charge.performed += ChargePressedInvoke;
        }

        private void OnDisable()
        {
            _inputAction.Regular.Jump.performed -= JumpedPressedInvoke;
            _inputAction.Regular.Charge.performed -= ChargePressedInvoke;
        }

        private void JumpedPressedInvoke(InputAction.CallbackContext _) => JumpPressed?.Invoke();
        private void ChargePressedInvoke(InputAction.CallbackContext _) => ChargePressed?.Invoke();
    }
}