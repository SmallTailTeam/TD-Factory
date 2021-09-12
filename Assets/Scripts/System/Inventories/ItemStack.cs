using System;

namespace TdFactory.System.Inventories
{
    public class ItemStack
    {
        public Action CountChanged { get; set; }

        public Item Item { get; set; }
        public int StackSize => Item.StackSize;
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                CountChanged?.Invoke();
            } 
        }
        public bool IsFull => Count >= StackSize;

        private int _count;
        
        public ItemStack(Item item)
        {
            Item = item;
        }
    }
}