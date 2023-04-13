using System;
using Source.Extentions;
using UnityEngine;

namespace Source.Gameplay.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    public class CharacterAnimation : NetworkTransformable
    {
        [Tooltip("Degrees per second")] [SerializeField] private float _rotationSpeed;
        
        private CharacterMovement Movement { get; set; }

        private void Awake()
        {
            Movement = GetComponent<CharacterMovement>();
        }

        private void Update()
        {
            RotateTowards(Movement.Velocity.normalized);
        }

        private void RotateTowards(Vector3 forward)
        {
            if (forward.Equals(Vector3.zero))
                return;
            
            float maxRadiansDelta = _rotationSpeed * Mathf.Deg2Rad;
            Vector3 lookDirection = Vector3.RotateTowards(Transform.forward, forward, maxRadiansDelta, Single.MaxValue);
            Transform.localRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        }
    }
}