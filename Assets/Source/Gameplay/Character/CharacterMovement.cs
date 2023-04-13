using System;
using System.Collections;
using Mirror;
using Source.Extentions;
using Unity.VisualScripting;
using UnityEngine;

namespace Source.Gameplay.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : NetworkBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _maxAccelerationTime;
        [Space]
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _gravity;
        [Space]
        [Tooltip("Minimum input magnitude to perform charge")] [Range(0, 1)] [SerializeField] private float _chargeSensitivity;
        [SerializeField] private float _chargeDelay;
        [SerializeField] private float _chargeDistance;
        [SerializeField] private float _chargeDuration;

        private CharacterController _controller;
        private Transform _cameraOrientation;
        private Coroutine _chargeCoroutine;
        private Vector2 _moveInput;

        private bool IsCharging => _chargeCoroutine != null;
        
        private Vector3 WorldMoveInput
        {
            get
            {
                Vector3 forward = CameraOrientation.forward.WithY(0).normalized;
                Vector3 right = CameraOrientation.right;
                return forward * _moveInput.y + right * _moveInput.x;
            }
        }

        public Transform CameraOrientation
        {
            get => _cameraOrientation;
            set
            {
                if (_cameraOrientation != null)
                    throw new InvalidOperatorException("CharacterMovement.Camera can only be set once", typeof(Transform));
                _cameraOrientation = value;
            }
        }

        public Vector3 Velocity { get; private set; }

        public void UpdatePlayerData(Vector2 moveInput)
        {
            if ( ! isLocalPlayer)
                return;
            _moveInput = moveInput;
        }

        public void Charge()
        {
            if (IsCharging || ! isLocalPlayer || WorldMoveInput.magnitude < _chargeSensitivity)
                return;
            _chargeCoroutine = StartCoroutine(Charging());
        }

        private IEnumerator Charging()
        {
            Vector3 direction = WorldMoveInput;
            yield return new WaitForSeconds(_chargeDelay);
            for (float i = 0; i < _chargeDuration; i += Time.fixedDeltaTime)
            {
                _controller.Move(direction * _chargeDistance / _chargeDuration * Time.fixedDeltaTime);
                yield return new WaitForFixedUpdate();
            }
            _chargeCoroutine = null;
        }

        private void InterruptCharge()
        {
            if ( ! IsCharging || ! isLocalPlayer)
                return;
            StopCoroutine(_chargeCoroutine);
            _chargeCoroutine = null;
        }

        public void Jump()
        {
            if ( ! isLocalPlayer)
                return;

            if (_controller.isGrounded)
                Velocity = Velocity.WithY(_jumpForce);
        }

        private void Move()
        {
            if ( ! isLocalPlayer || IsCharging)
                return;
            
            Vector3 targetVelocty = WorldMoveInput * _maxSpeed;
            float maxVelocityDelta = _maxSpeed / _maxAccelerationTime * Time.fixedDeltaTime;
            
            Velocity = Vector3.MoveTowards(Velocity.WithY(0), targetVelocty, maxVelocityDelta).WithY(Velocity.y);
            Velocity = Velocity.WithY(Velocity.y - _gravity * Time.fixedDeltaTime);
            
            _controller.Move(Velocity * Time.fixedDeltaTime);
        }

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            InterruptCharge();
        }
    }
}