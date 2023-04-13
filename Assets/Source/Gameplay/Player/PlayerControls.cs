using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Gameplay.Player
{
    public class PlayerControls : MonoBehaviour
    {
        private PlayerInputActions _inputAction;

        public Vector2 Movement => _inputAction.Regular.Movement.ReadValue<Vector2>();
        public Vector2 CameraOrbit => _inputAction.Always.CameraOrbit.ReadValue<Vector2>();

        public delegate void PlayerInputHandler(InputAction.CallbackContext context);

        public event PlayerInputHandler JumpPressed;
        
        private void Awake()
        {
            _inputAction = new PlayerInputActions();
            _inputAction.Enable();
        }
    }
}