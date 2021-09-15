using TdFactory.System.Inventories;
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
                _iconImage.sprite = itemStack.Item.Sprite;
                _countText.text = itemStack.Count.ToString();
            }
        }
    }
}