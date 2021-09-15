using TdFactory.Entities;
using TdFactory.System.Items;
using UnityEngine;

namespace TdFactory.UI.HUD
{
    public class InventoryHUD : PlayerHUD
    {
        [SerializeField] private InventorySlot _slot;

        protected override KeyCode UseKey() => KeyCode.Tab;
        
        private void Start()
        {
            foreach (ItemStack itemStack in Player.Me.Inventory.Slots)
            {
                InventorySlot slot = Instantiate(_slot, transform);
                slot.Bind(itemStack);
            }
        }
    }
}