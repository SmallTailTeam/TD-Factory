namespace TdFactory.Core.Entities
{
    public class Inventory
    {
        public ItemStack[] Slots;
        public int SlotCount => Slots.Length;

        public Inventory(int slotCount)
        {
            Slots = new ItemStack[slotCount];
        }

        public void AddItem(Item item)
        {
            ItemStack itemStack = null;
            
            for (int i = 0; i < SlotCount; i++)
            {
                itemStack = Slots[i];

                if (itemStack != null && itemStack.Item == item && !itemStack.IsFull)
                {
                    break;
                }
            }

            if (itemStack == null)
            {
                int freeSlot = FindFreeSlot();

                if (freeSlot == -1)
                {
                    return;
                }
                
                itemStack = new ItemStack(item);
                Slots[freeSlot] = itemStack;
            }

            itemStack.Count++;
        }
        
        public ItemStack GetSlot(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex >= Slots.Length)
            {
                return null;
            }

            return Slots[slotIndex];
        }

        public int FindFreeSlot()
        {
            for (int i = 0; i < SlotCount; i++)
            {
                if (Slots[i] == null)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}