using UnityEngine;

namespace TdFactory.UI.Windows
{
    public class WindowManager : MonoBehaviour
    {
        public Window Create(string windowName)
        {
            Window prefab = Resources.Load<Window>($"UI/Windows/{windowName}/Root");
            
            Window instance = Instantiate(prefab, transform);
            
            return instance;
        }
    }
}