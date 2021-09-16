using TdFactory.Entities;
using TdFactory.System.Items;
using UnityEngine;

namespace TdFactory.UI.HUD
{
    public class InventoryHUD : TogglableHUD
    {
        [SerializeField] private InventorySlot _slot;

        protected override KeyCode UseKey() => KeyCode.Tab;
        
        private void Start()
        {
            for (int i = 9; i < Player.Me.Inventory.Slots.Length; i++)
            {
                ItemStack itemStack = Player.Me.Inventory.Slots[i];
                InventorySlot slot = Instantiate(_slot, transform);
                slot.Bind(itemStack);
            }
        }
    }
}