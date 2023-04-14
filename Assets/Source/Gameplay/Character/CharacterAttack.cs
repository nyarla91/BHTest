using UnityEngine;

namespace Source.Gameplay.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    public class CharacterAttack : MonoBehaviour
    {
        private CharacterMovement Movement { get; set; }
        
        private void Awake()
        {
            Movement = GetComponent<CharacterMovement>();
            Movement.HitWithCharge += TryAttack;
        }

        private void TryAttack(Collider obj)
        {
            
        }
    }
}