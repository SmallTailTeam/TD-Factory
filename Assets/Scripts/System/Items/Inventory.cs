using System;
using System.Collections.Generic;

namespace TdFactory.System.Items
{
    public class Inventory
    {
        public Action<Item> ItemAdded { get; set; }

        public ItemStack[] Slots;
        public int SlotCount => Slots.Length;

        public Inventory(int slotCount)
        {
            Slots = new ItemStack[slotCount];

            for (int i = 0; i < slotCount; i++)
            {
                Slots[i] = new ItemStack(null);
            }
        }

        public void AddItem(Item item)
        {
            ItemStack itemStack = null;
            
            for (int i = 0; i < SlotCount; i++)
            {
                if (Slots[i].Item == item && !Slots[i].IsFull)
                {
                    itemStack = Slots[i];
                    break;
                }
            }

            if (itemStack == null)
            {
                int freeSlot = GetFirstFreeSlot();

                if (freeSlot == -1)
                {
                    return;
                }

                itemStack = Slots[freeSlot];
                itemStack.Item = item;
            }

            itemStack.Count++;
            
            ItemAdded?.Invoke(item);
        }

        public void RemoveItem(Item item, int count = 1)
        {
            IEnumerable<ItemStack> itemSlots = GetAllItemSlots(item);

            foreach (ItemStack itemStack in itemSlots)
            {
                if (count == 0)
                {
                    return;
                }
                
                if (count >= itemStack.Count)
                {
                    count -= itemStack.Count;
                    itemStack.Count = 0;
                }
                else
                {
                    itemStack.Count -= count;
                    count = 0;
                }
            }
        }
        
        public bool HasItem(Item item, int count = 1)
        {
            int found = 0;

            foreach (ItemStack itemStack in Slots)
            {
                if (itemStack.Item == item)
                {
                    found += itemStack.Count;

                    if (found >= count)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public IEnumerable<ItemStack> GetAllItemSlots(Item item)
        {
            foreach (ItemStack itemStack in Slots)
            {
                if (itemStack.Item == item)
                {
                    yield return itemStack;
                }
            }
        }

        public ItemStack GetSlot(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex >= Slots.Length)
            {
                return null;
            }

            return Slots[slotIndex];
        }

        public int GetFirstFreeSlot()
        {
            for (int i = 0; i < SlotCount; i++)
            {
                if (Slots[i].Item == null)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}