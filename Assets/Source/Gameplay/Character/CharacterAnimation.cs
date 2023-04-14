using System;
using Source.Extentions;
using UnityEngine;

namespace Source.Gameplay.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    public class CharacterAnimation : NetworkTransformable
    {
        [SerializeField] private Animator _animator;
        [Space]
        [Tooltip("Degrees per second")] [SerializeField] private float _rotationSpeed;
        [Tooltip("Minimum movement to rotate towards to")] [SerializeField] private float _rotationSensitivity;
        
        private CharacterMovement Movement { get; set; }

        private void Awake()
        {
            Movement = GetComponent<CharacterMovement>();
        }

        private void FixedUpdate()
        {
            RotateTowards(Movement.Velocity.WithY(0), Time.fixedDeltaTime);
            UpdateAnimatorParameters();
        }

        private void RotateTowards(Vector3 forward, float deltaTime)
        {
            if ( ! isServer || forward.magnitude < _rotationSensitivity)
                return;
            
            float maxRadiansDelta = _rotationSpeed * deltaTime * Mathf.Deg2Rad;
            Vector3 lookDirection = Vector3.RotateTowards(Transform.forward, forward, maxRadiansDelta, Single.MaxValue);
            Transform.localRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        }

        private void UpdateAnimatorParameters()
        {
            if ( ! isServer)
                return;
            
            _animator.SetBool("IsGrounded", Movement.IsGrounded);
            _animator.SetBool("IsCharging", Movement.IsCharging);
            float movementSpeed = Movement.Velocity.WithY(0).magnitude;
            _animator.SetFloat("MovementSpeed", movementSpeed);
            _animator.SetBool("IsMoving", movementSpeed > _rotationSensitivity);
        }
    }
}