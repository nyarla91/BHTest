using Source.Extentions;
using Source.Gameplay.Character;
using UnityEngine;

namespace Source.Gameplay.Player
{
    [RequireComponent(typeof(PlayerControls))]
    public class PlayerPresenter : Transformable
    {
        [SerializeField] private GameObject _playerCameraPrefab;
        
        private CharacterComposition _composition;

        private PlayerControls Controls { get; set; }
        private PlayerCamera Camera { get; set; }

        public void Init(CharacterComposition character)
        {
            _composition = character;
            
            Camera = Instantiate(_playerCameraPrefab, Transform.position, Quaternion.identity).GetComponent<PlayerCamera>();
            Camera.Init(character.Transform);
            
            Controls = GetComponent<PlayerControls>();
            Controls.JumpPressed += _composition.Movement.CmdJump;
            Controls.ChargePressed += _composition.Movement.CmdCharge;
        }

        private void FixedUpdate()
        {
            _composition.Movement.CmdSetWorldMoveInput(Camera.MoveInputToWorld(Controls.Movement));
        }

        private void Update()
        {
            Camera.Rotate(Controls.CameraOrbit);
        }
    }
}