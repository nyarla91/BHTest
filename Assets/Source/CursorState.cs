using UnityEngine;

namespace Source
{
    public class CursorState : MonoBehaviour
    {
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}