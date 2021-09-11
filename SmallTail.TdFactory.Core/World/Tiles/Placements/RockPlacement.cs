using SFML.Graphics;
using SFML.System;
using TdFactory.Core.Graphics;
using TdFactory.Core.Mathematics;

namespace TdFactory.Core.World.Tiles.Placements
{
    public class RockPlacement : Placement
    {
        public override void Initialize()
        {
            Texture texture = AssetManager.LoadTexture($"Assets/Tiles/Rock.png");
            
            Sprite = new Sprite
            {
                Texture = AssetManager.LoadTexture($"Assets/Tiles/Rock.png"),
                Scale = new Vector2f(DoRandom.Generate(80, 100) / (float)texture.Size.X, DoRandom.Generate(80, 100) / (float)texture.Size.Y)
            };
        }
    }
}