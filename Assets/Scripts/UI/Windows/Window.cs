using UnityEngine;

namespace TdFactory.UI.Windows
{
    public class Window : MonoBehaviour
    {
        public void Close()
        {
            Destroy(gameObject);
        }
    }
}