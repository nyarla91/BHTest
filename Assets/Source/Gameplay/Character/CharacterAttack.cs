using System;
using Mirror;
using UnityEngine;

namespace Source.Gameplay.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    public class CharacterAttack : NetworkBehaviour
    {
        private CharacterMovement Movement { get; set; }

        [SyncVar]
        private int _succesfulHits;

        public int SuccesfulHits => _succesfulHits;

        public event Action<CharacterAttack, int> SuccesfulHitsUpdated;

        public void Restart()
        {
            _succesfulHits = 0;
            SuccesfulHitsUpdated?.Invoke(this, _succesfulHits);
        }

        private void Awake()
        {
            Movement = GetComponent<CharacterMovement>();
            Movement.HitWithCharge += TryAttack;
        }

        private void TryAttack(Collider hit)
        {
            if ( ! isServer || ! hit.TryGetComponent(out CharacterLife victim) || ! victim.TryHit())
                return;
            _succesfulHits++;
            SuccesfulHitsUpdated?.Invoke(this, _succesfulHits);
        }
    }
}