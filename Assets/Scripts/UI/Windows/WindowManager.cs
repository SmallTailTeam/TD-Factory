using UnityEngine;

namespace TdFactory.UI.Windows
{
    public class WindowManager : MonoBehaviour
    {
        public T Create<T>(string windowName) where T : Window
        {
            Window prefab = Resources.Load<Window>($"UI/Windows/{windowName}/Root");
            
            Window instance = Instantiate(prefab, transform);
            
            return instance as T;
        }
    }
}