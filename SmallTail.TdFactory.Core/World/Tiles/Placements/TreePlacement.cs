using SFML.Graphics;
using SFML.System;
using TdFactory.Core.Entities;
using TdFactory.Core.Graphics;
using TdFactory.Core.Mathematics;

namespace TdFactory.Core.World.Tiles.Placements
{
    public class TreePlacement : Placement
    {
        public override void Initialize()
        {
            Texture texture = AssetManager.LoadTexture($"Assets/Tiles/Tree_0{DoRandom.Generate(1, 6)}.png");
            
            Sprite = new Sprite
            {
                Texture = texture,
                Scale = new Vector2f(DoRandom.Generate(200, 300) / (float)texture.Size.X, DoRandom.Generate(200, 300) / (float)texture.Size.Y)
            };
            
            Sprite.Origin = new Vector2f(640f / 2f, 624f);
        }

        public override void Interact(Player player)
        {
            player.Inventory.AddItem(Items.WoodenPlanks);
            Tile.Main = null;
        }
    }
}