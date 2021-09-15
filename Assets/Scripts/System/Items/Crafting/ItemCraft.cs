namespace TdFactory.System.Items.Crafting
{
    public class ItemCraft
    {
        public CraftComponent[] Components;

        public ItemCraft(params CraftComponent[] components)
        {
            Components = components;
        }

        public static void Craft(Item item, Inventory inventory)
        {
            if (item.ItemCraft == null)
            {
                return;
            }

            foreach (CraftComponent component in item.ItemCraft.Components)
            {
                if (!inventory.HasItem(component.Item, component.Count))
                {
                    return;
                }
            }

            foreach (CraftComponent component in item.ItemCraft.Components)
            {
                inventory.RemoveItem(component.Item, component.Count);
            }
            
            inventory.AddItem(item);
        }
    }
}