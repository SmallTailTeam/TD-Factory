using SFML.Graphics;
using SFML.System;
using TdFactory.Core.Graphics;
using TdFactory.Core.Mathematics;

namespace TdFactory.Core.World.Tiles.Placements
{
    public class GrassPlacement : Placement
    {
        public override void Initialize()
        {
            float a = Noise.CalcPixel2D(Tile.X, Tile.Y, 100.53f);

            Sprite = new Sprite
            {
                Texture = AssetManager.LoadTexture("Assets/Tiles/Grass.png"),
                Color = new Color((byte)(150 + a * 0.15f), (byte)(200 + a * 0.1f), (byte)(10 + a * 0.05f)),
                Scale = new Vector2f(Universe.TileSize / 512f, Universe.TileSize / 512f)
            };
        }
    }
}