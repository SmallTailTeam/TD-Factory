using UnityEngine;

namespace TdFactory.UI.HUD
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class PlayerHUD : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        
        protected abstract KeyCode UseKey();

        protected virtual void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
        
        protected virtual void Update()
        {
            if (Input.GetKeyDown(UseKey()))
            {
                if (_canvasGroup.alpha == 0f)
                {
                    Show();
                }
                else
                {
                    Hide();
                }
            }
        }

        protected virtual void Show()
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
        
        protected virtual void Hide()
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}