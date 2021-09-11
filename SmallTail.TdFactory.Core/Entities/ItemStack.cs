namespace TdFactory.Core.Entities
{
    public class ItemStack
    {
        public Item Item { get; set; }
        public int StackSize => Item.StackSize;
        public int Count { get; set; }
        public bool IsFull => Count >= StackSize;

        public ItemStack(Item item)
        {
            Item = item;
        }
    }
}