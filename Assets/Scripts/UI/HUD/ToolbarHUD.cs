using TdFactory.Entities;
using UnityEngine;

namespace TdFactory.UI.HUD
{
    public class ToolbarHUD : MonoBehaviour
    {
        [SerializeField] private InventorySlot _slotPrefab;
        [SerializeField] private int _size;

        private void Start()
        {
            for (int i = 0; i < _size; i++)
            {
                InventorySlot slot = Instantiate(_slotPrefab, transform);
                slot.Bind(Player.Me.Inventory.Slots[i]);
            }
        }

        private void Update()
        {
            if (Input.inputString != "")
            {
                if (int.TryParse(Input.inputString, out int number))
                {
                    if (number > 0 && number < 10)
                    {
                        Player.Me.HeldItem = Player.Me.Inventory.Slots[number - 1];
                    }
                }
            }
        }
    }
}