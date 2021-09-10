using SFML.Graphics;
using SFML.System;

namespace TdFactory.Core.World.Tiles
{
    public class Tile : IComputer, IRenderer
    {
        public Sprite Sprite;
        public int X;
        public int Y;
        public int Elevation;

        public Tile(int x, int y)
        {
            X = x;
            Y = y;

            Sprite = new Sprite
            {
                Position = new Vector2f(x * Universe.TileSize, y * Universe.TileSize)
            };
        }
        
        public virtual void Compute(float dt, float fixedDt) {}

        public virtual void Render(float dt)
        {
            Game.Window.Draw(Sprite);
        }
    }
}