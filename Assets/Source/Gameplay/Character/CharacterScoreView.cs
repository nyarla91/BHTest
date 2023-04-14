using Mirror;
using TMPro;
using UnityEngine;

namespace Source.Gameplay.Character
{
    [RequireComponent(typeof(CharacterAttack))]
    public class CharacterScoreView : NetworkBehaviour
    {
        [SerializeField] private TMP_Text _counter;

        private CharacterAttack Attack { get; set; }
        
        private void Awake()
        {
            Attack = GetComponent<CharacterAttack>();
        }

        private void Update()
        {
            UpdateCounter(Attack.SuccesfulHits); 
        }

        private void UpdateCounter(int hits)
        {
            _counter.text = hits.ToString();
        }
    }
}