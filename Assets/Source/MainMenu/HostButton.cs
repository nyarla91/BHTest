using UnityEngine;

namespace Source.MainMenu
{
    public class HostButton : MonoBehaviour
    {
        public void Host()
        {
            NetworkManager.Singleton.StartHost();
        }
    }
}