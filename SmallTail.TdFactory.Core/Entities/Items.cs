using System.Collections.Generic;
using TdFactory.Core.Graphics;

namespace TdFactory.Core.Entities
{
    public static class Items
    {
        public static Item WoodenPlanks = new ()
        {
            StackSize = 300,
            Texture = AssetManager.LoadTexture("Assets/Items/WoodenPlanks.png"),
            Tags = new List<ItemTag>
            {
                new ("BurnTime", 10)
            }
        };
    }
}