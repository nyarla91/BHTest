using System;
using System.Collections;
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
        [Space]
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _gravity;
        [Space]
        [Tooltip("Minimum input magnitude to perform charge")] [Range(0, 1)] [SerializeField] private float _chargeSensitivity;
        [SerializeField] [Range(0, 90)] private float _chargeStopMinAngle;
        [SerializeField] private float _chargeDelay;
        [SerializeField] private float _chargeDistance;
        [SerializeField] private float _chargeDuration;

        private CharacterController _controller;
        private Coroutine _chargeCoroutine;

        private bool IsCharging => _chargeCoroutine != null;
        
        private Vector3 WorldMoveInput { get; set; }

        public Vector3 Velocity { get; private set; }

        public event Action<Collider> HitWithCharge;

        [Command]
        public void CmdSetWorldMoveInput(Vector3 worldMoveInput)
        {
            WorldMoveInput = Vector3.ClampMagnitude(worldMoveInput.WithY(0), 1);
        }

        [Command]
        public void CmdCharge()
        {
            if (IsCharging || WorldMoveInput.magnitude < _chargeSensitivity)
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

        private bool TryInterruptCharge()
        {
            if ( ! IsCharging || ! isServer)
                return false;
            StopCoroutine(_chargeCoroutine);
            _chargeCoroutine = null;
            return true;
        }

        [Command]
        public void CmdJump()
        {
            if (_controller.isGrounded) 
                Velocity = Velocity.WithY(_jumpForce);
        }

        private void Move()
        {
            if ( ! isServer || IsCharging)
                return;
            
            Vector3 targetVelocty = WorldMoveInput * _maxSpeed;
            float maxVelocityDelta = _maxSpeed / _maxAccelerationTime * Time.fixedDeltaTime;
            Velocity = Vector3.MoveTowards(Velocity.WithY(0), targetVelocty, maxVelocityDelta).WithY(Velocity.y);

            float ySpeed = Velocity.y;
            if (_controller.isGrounded && Velocity.y < 0)
                ySpeed = 0;
            ySpeed -= _gravity * Time.fixedDeltaTime;
            Velocity = Velocity.WithY(ySpeed);
            
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
            if (Vector3.Angle(hit.normal, Vector3.up) < _chargeStopMinAngle)
                return;
            
            if (TryInterruptCharge())
                HitWithCharge?.Invoke(hit.collider);
        }
    }
}