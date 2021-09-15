using System.Collections.Generic;
using UnityEngine;

namespace TdFactory.System.Inventories
{
    public static class Items
    {
        public static Item Planks = new Item
        {
            StackSize = 30,
            Sprite = Resources.Load<Sprite>("Items/Planks"),
            Tags = new List<ItemTag>
            {
                new ItemTag("BurnTime", 10)
            }
        };
    }
}