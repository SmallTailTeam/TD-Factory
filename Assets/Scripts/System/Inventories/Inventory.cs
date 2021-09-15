using System;
using UnityEngine;

namespace TdFactory.System.Inventories
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
                int freeSlot = FindFreeSlot();

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
                if (Slots[i].Item == null)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}