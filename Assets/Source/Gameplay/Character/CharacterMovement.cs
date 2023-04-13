using Mirror;
using UnityEngine;

namespace Source.Gameplay.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : NetworkBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _maxAccelerationTime;

        private CharacterController _controller;
        private Vector3 _velocity;

        public void Move(Vector2 inputDelta, float deltaTime)
        {
            
        }

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }
    }
}