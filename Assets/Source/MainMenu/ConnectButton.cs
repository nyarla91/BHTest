using TMPro;
using UnityEngine;

namespace Source.MainMenu
{
    public class ConnectButton : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _ip;
        
        public void Connect()
        {
            NetworkManager.Singleton.networkAddress = _ip.text;
            NetworkManager.Singleton.StartClient();
        }
    }
}