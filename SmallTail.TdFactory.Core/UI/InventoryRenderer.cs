using TdFactory.Core.Entities;
using TdFactory.Core.System;

namespace TdFactory.Core.UI
{
    public class InventoryRenderer : IRenderer
    {
        private Inventory _inventory;
        private ItemStackRenderer[] _stackRenderers;

        public InventoryRenderer(Inventory inventory)
        {
            _inventory = inventory;
            
            _stackRenderers = new ItemStackRenderer[_inventory.SlotCount];
            for (int i = 0; i < _inventory.SlotCount; i++)
            {
                _stackRenderers[i] = new ItemStackRenderer(i);
            }
        }

        public void Render(float dt)
        {
            for (int i = 0; i < _inventory.SlotCount; i++)
            {
                ItemStackRenderer stackRenderer = _stackRenderers[i];
                stackRenderer.Target = _inventory.Slots[i];
                stackRenderer.Render(dt);
            }
        }
    }
}