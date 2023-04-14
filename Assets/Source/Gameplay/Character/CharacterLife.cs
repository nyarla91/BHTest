using Mirror;
using UnityEngine;

namespace Source.Gameplay.Character
{
    public class CharacterLife : NetworkBehaviour
    {
        [SerializeField] private float _damageImmunityTime;

        private float _immunityTimeLeft;
        
        private bool Immune => _immunityTimeLeft > 0;

        public bool TryHit()
        {
            if ( ! isServer || Immune)
                return false;
            _immunityTimeLeft = _damageImmunityTime;
            return true;
        }

        private void FixedUpdate()
        {
            if ( ! isServer)
                return;
            _immunityTimeLeft -= Time.fixedDeltaTime;
        }
    }
}