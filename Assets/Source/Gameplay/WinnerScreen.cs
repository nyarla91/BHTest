using Mirror;
using TMPro;
using UnityEngine;

namespace Source.Gameplay
{
    public class WinnerScreen : NetworkBehaviour
    {
        [SerializeField] private GameEndCodition _gameEndCodition;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TMP_Text _message;

        private void Awake()
        {
            _gameEndCodition.GameEnded += Show;
            _gameEndCodition.GameRestarted += Hide;
            Hide();
        }

        private void Hide()
        {
            _canvasGroup.alpha = 0;
        }

        private void Show(string winnerName)
        {
            _canvasGroup.alpha = 1;
            _message.text = $"The winner is {winnerName}!";
        }
    }
}