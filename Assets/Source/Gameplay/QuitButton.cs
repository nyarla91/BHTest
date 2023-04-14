using Mirror;

namespace Source.Gameplay
{
    public class QuitButton : NetworkBehaviour
    {
        public void Quit()
        {
            if (isClientOnly)
                NetworkManager.Singleton.StopClient();
            else if (isServerOnly)
                NetworkManager.Singleton.StopServer();
            else
                NetworkManager.Singleton.StopHost();
        }
    }
}