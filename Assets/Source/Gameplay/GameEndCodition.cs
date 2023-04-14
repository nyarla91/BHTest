using System;
using System.Collections;
using Mirror;
using Source.Gameplay.Character;
using UnityEngine;

namespace Source.Gameplay
{
    public class GameEndCodition : NetworkBehaviour
    {
        [SerializeField] private int _scoreToWin;
        [SerializeField] private float _restartTime;

        private bool _isGameEnded;

        public event Action<string> GameEnded;
        public event Action GameRestarted;

        private void Awake()
        {
            foreach (CharacterComposition composition in NetworkManager.Singleton.PlayerObjects)
            {
                SubscribeForPlayer(composition);
            }
            
            NetworkManager.Singleton.PlayerAdded += SubscribeForPlayer;
            NetworkManager.Singleton.PlayerRemoved += UnsubscribeFromPlayer;
        }

        private void SubscribeForPlayer(CharacterComposition composition)
        {
            composition.Attack.SuccesfulHitsUpdated += TryEndGame;
        }

        private void UnsubscribeFromPlayer(CharacterComposition composition)
        {
            composition.Attack.SuccesfulHitsUpdated -= TryEndGame;
        }

        private void TryEndGame(CharacterAttack character, int hits)
        {
            if ( ! isServer || _isGameEnded || hits < _scoreToWin)
                return;
            
            _isGameEnded = true;
            RpcGameEnded(character.gameObject.name);
            StartCoroutine(Restart());
        }

        private IEnumerator Restart()
        {
            yield return new WaitForSeconds(_restartTime);
            _isGameEnded = false;
            foreach (CharacterComposition composition in NetworkManager.Singleton.PlayerObjects)
            {
                composition.Restart();
            }
            RpcGameRestarted();
        }

        [ClientRpc]
        private void RpcGameEnded(string winnerName)
        {
            GameEnded?.Invoke(winnerName);
        }

        [ClientRpc]
        private void RpcGameRestarted()
        {
            GameRestarted?.Invoke();
        }
    }
}