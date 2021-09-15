using System.Collections.Generic;
using TdFactory.System.Items.Crafting;
using UnityEngine;

namespace TdFactory.System.Items
{
    public static class ItemDefs
    {
        private static readonly List<Item> _items = new List<Item>
        {
            new Item
            {
                Id = "TdFactory/Planks",
                StackSize = 30,
                Sprite = Resources.Load<Sprite>("Items/Planks"),
                Tags =
                {
                    new ItemTag("BurnTime", 10)
                }
            },
            new Item
            {
                Id = "TdFactory/WoodenWall",
                StackSize = 10,
                Sprite = Resources.Load<Sprite>("Items/WoodenWall"),
                Tags = 
                {
                    new ItemTag("BurnTime", 50)
                },
                ItemCraft = new ItemCraft(new CraftComponent("TdFactory/Planks", 5))
            }
        };

        public static Item Find(string itemId)
        {
            foreach (Item item in _items)
            {
                if (item.Id == itemId)
                {
                    return item;
                }
            }

            return null;
        }
    }
}