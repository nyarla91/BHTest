using Source.Extentions;
using Source.Gameplay.Player;
using UnityEngine;

namespace Source.Gameplay.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    [RequireComponent(typeof(CharacterAttack))]
    public class CharacterComposition : NetworkTransformable
    {
        [Tooltip("Only spawned for local player")] [SerializeField] private GameObject _playerPrefab;

        public CharacterMovement Movement { get; private set; }
        public CharacterAttack Attack { get; private set; }

        public void Restart()
        {
            Movement.Restart();
            Attack.Restart();
        }

        private void Awake()
        {
            Movement = GetComponent<CharacterMovement>();
            Attack = GetComponent<CharacterAttack>();
        }

        private void Start()
        {
            InitLocalPlayer();
        }

        private void InitLocalPlayer()
        {
            if ( ! isLocalPlayer)
                return;
            PlayerPresenter presenter = Instantiate(_playerPrefab, Transform).GetComponent<PlayerPresenter>();
            presenter.Init(this);
        }
    }
}