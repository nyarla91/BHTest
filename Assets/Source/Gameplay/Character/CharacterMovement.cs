using Mirror;
using Source.Extentions;
using UnityEngine;

namespace Source.Gameplay.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : NetworkBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _maxAccelerationTime;

        private CharacterController _controller;
        public Vector3 Velocity { get; private set; }

        public void Move(Vector2 inputDelta, Transform cameraOrientation, float deltaTime)
        {
            Vector3 forward = cameraOrientation.forward.WithY(0).normalized;
            Vector3 right = cameraOrientation.right;
            Vector3 targetVelocty = (forward * inputDelta.y + right * inputDelta.x) * _maxSpeed;
            
            float maxVelocityDelta = _maxSpeed / _maxAccelerationTime * deltaTime;
            Velocity = Vector3.MoveTowards(Velocity, targetVelocty, maxVelocityDelta);

            _controller.Move(Velocity * deltaTime);
        }

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }
    }
}