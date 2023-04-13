using Source.Extentions;
using UnityEngine;

namespace Source.Gameplay.Player
{
    public class PlayerCamera : Transformable
    {
        [SerializeField] private Transform _origin;
        [SerializeField] private Transform _camera;
        [Space]
        [SerializeField] private float _maxDistance;
        [Range(60, 90)] [SerializeField] private float _verticalAmplitude;
        [SerializeField] private float _mouseSensitivity;

        private Transform _target;

        public void Init(Transform target)
        {
            _target = target;
        }

        public void Rotate(Vector2 inputDelta)
        {
            inputDelta *= _mouseSensitivity;
            Vector3 localEulers = Transform.localRotation.eulerAngles;
            
            float verticalAngle = localEulers.x;
            verticalAngle -= inputDelta.y;
            verticalAngle = verticalAngle.ClampAngle(360 - _verticalAmplitude, _verticalAmplitude);
            
            Transform.localRotation = Quaternion.Euler(localEulers.WithX(verticalAngle));
            Transform.Rotate(0, inputDelta.x, 0, Space.World);
        }

        private void Update()
        {
            Transform.position = _target.position;
            _camera.localPosition = new Vector3(0, 0, -GetCameraDistance());
        }

        private float GetCameraDistance()
        {
            Ray ray = new Ray(_origin.position, - _origin.forward);
            LayerMask mask = LayerMask.GetMask("Surface");
            return Physics.Raycast(ray, out RaycastHit raycastHit, _maxDistance, mask) ? raycastHit.distance : _maxDistance;
        }
    }
}