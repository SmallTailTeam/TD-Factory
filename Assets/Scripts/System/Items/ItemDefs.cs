using System.Collections.Generic;
using TdFactory.Planets.Placements.Defenses;
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
            new ItemBuildable<WoodenWallPlacement>
            {
                Id = "TdFactory/WoodenWall",
                StackSize = 10,
                Sprite = Resources.Load<Sprite>("Items/WoodenWall"),
                Tags = 
                {
                    new ItemTag("BurnTime", 50)
                },
                Craft = new ItemCraft(new CraftComponent("TdFactory/Planks", 5))
            },
            new Item
            {
                Id = "TdFactory/IronOre",
                StackSize = 300,
                Sprite = Resources.Load<Sprite>("Tiles/IronOreSource")
            },
            new Item
            {
                Id = "TdFactory/PrimitiveCpu",
                StackSize = 100,
                Sprite = Resources.Load<Sprite>("Items/PrimitiveCpu"),
                Craft = new ItemCraft(new CraftComponent("TdFactory/IronOre", 35))
            },
            new ItemBuildable<PrimitiveTurretPlacement>
            {
                Id = "TdFactory/PrimitiveTurret",
                StackSize = 100,
                Sprite = Resources.Load<Sprite>("Tiles/PrimitiveTurretHead"),
                Craft = new ItemCraft(new CraftComponent("TdFactory/PrimitiveCpu", 1),
                    new CraftComponent("TdFactory/IronOre", 5))
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