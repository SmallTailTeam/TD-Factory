using System;
using Newtonsoft.Json;

namespace TdFactory.System.Items
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

                if (_count <= 0)
                {
                    Item = null;
                }
                
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