namespace TdFactory.System.Items.Crafting
{
    public class CraftComponent
    {
        public Item Item => ItemDefs.Find(ItemId);
        public string ItemId;
        public int Count;

        public CraftComponent(string itemId, int count)
        {
            ItemId = itemId;
            Count = count;
        }
    }
}