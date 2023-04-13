using System;
using Source.Extentions;
using Source.Gameplay.Character;
using UnityEngine;

namespace Source.Gameplay.Player
{
    [RequireComponent(typeof(PlayerControls))]
    public class PlayerPresenter : Transformable
    {
        [SerializeField] private GameObject _playerCameraPrefab;
        
        private CharacterComposition _character;

        private PlayerControls Controls { get; set; }
        private PlayerCamera Camera { get; set; }

        public void Init(CharacterComposition character)
        {
            _character = character;
            Camera = Instantiate(_playerCameraPrefab, Transform.position, Quaternion.identity).GetComponent<PlayerCamera>();
            Camera.Init(character.Transform);
        }

        private void Awake()
        {
            Controls = GetComponent<PlayerControls>();
        }

        private void FixedUpdate()
        {
            _character.Movement.Move(Controls.Movement, Camera.Transform, Time.fixedDeltaTime);
        }

        private void Update()
        {
            Camera.Rotate(Controls.CameraOrbit);
        }
    }
}