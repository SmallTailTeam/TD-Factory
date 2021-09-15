using TdFactory.System.Items;
using UnityEngine;
using UnityEngine.UI;

namespace TdFactory.UI.HUD
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private Text _countText;
        
        public void Bind(ItemStack itemStack)
        {
            itemStack.CountChanged += () => Display(itemStack);
            Display(itemStack);
        }

        private void Display(ItemStack itemStack)
        {
            if (itemStack.Item != null)
            {
                _iconImage.color = new Color(1, 1, 1, 1);
                _iconImage.sprite = itemStack.Item.Sprite;
                _countText.text = itemStack.Count.ToString();
            }
            else
            {
                _iconImage.color = new Color(0, 0, 0, 0);
                _countText.text = "";
            }
        }
    }
}