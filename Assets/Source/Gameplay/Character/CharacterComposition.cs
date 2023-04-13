using Source.Extentions;
using Source.Gameplay.Player;
using UnityEngine;

namespace Source.Gameplay.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    public class CharacterComposition : NetworkTransformable
    {
        [Tooltip("Only spawned for local player")] [SerializeField] private GameObject _playerPrefab;

        public CharacterMovement Movement { get; private set; }

        private void Awake()
        {
            Movement = GetComponent<CharacterMovement>();
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
            print(presenter);
            presenter.Init(this);
        }
    }
}