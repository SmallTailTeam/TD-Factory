using TdFactory.System;
using UnityEngine;
using UnityEngine.UI;

namespace TdFactory.UI.Windows
{
    public class IdeWindow : Window
    {
        [SerializeField] private InputField _codeEditor;

        private IProgrammable _link;

        private void ValueChanged(string code)
        {
            _link.Code = code;
        }

        public void LinkTo(IProgrammable programmable)
        {
            _link = programmable;
            
            _codeEditor.text = _link.Code;
            _codeEditor.onValueChanged.AddListener(ValueChanged);
        }
    }
}