using Mirror;
using UnityEngine;

namespace Source
{
    public class CursorState : NetworkBehaviour
    {
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}