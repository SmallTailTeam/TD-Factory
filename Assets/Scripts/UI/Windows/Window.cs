using System;
using UnityEngine;

namespace TdFactory.UI.Windows
{
    public class Window : MonoBehaviour
    {
        public Action Closed { get; set; }
        
        public void Close()
        {
            Closed?.Invoke();
            Destroy(gameObject);
        }
    }
}