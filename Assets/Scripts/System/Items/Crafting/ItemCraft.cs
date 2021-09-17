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
            if (item.Craft == null)
            {
                return;
            }

            foreach (CraftComponent component in item.Craft.Components)
            {
                if (!inventory.HasItem(component.Item, component.Count))
                {
                    return;
                }
            }

            foreach (CraftComponent component in item.Craft.Components)
            {
                inventory.RemoveItem(component.Item, component.Count);
            }
            
            inventory.AddItem(item);
        }
    }
}