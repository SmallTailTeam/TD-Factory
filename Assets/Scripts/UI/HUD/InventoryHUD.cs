using TdFactory.Entities;
using TdFactory.System.Inventories;
using UnityEngine;

namespace TdFactory.UI.HUD
{
    public class InventoryHUD : MonoBehaviour
    {
        [SerializeField] private InventorySlot _slot;

        private void Start()
        {
            foreach (ItemStack itemStack in Player.My.Inventory.Slots)
            {
                InventorySlot slot = Instantiate(_slot, transform);
                slot.Bind(itemStack);
            }
        }
    }
}