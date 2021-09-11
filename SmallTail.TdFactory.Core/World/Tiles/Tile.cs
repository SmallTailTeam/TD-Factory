using SFML.System;
using TdFactory.Core.System;
using TdFactory.Core.World.Tiles.Placements;

namespace TdFactory.Core.World.Tiles
{
    public class Tile : IComputer
    {
        public Placement Floor;
        public Placement Main;
        public Placement Roof;
        public int X;
        public int Y;
        public int Elevation;

        public Tile(int x, int y)
        {
            X = x;
            Y = y;

            PlaceFloor(new GrassPlacement());
        }

        public void PlaceFloor(Placement floor)
        {
            floor.Tile = this;
            floor.Initialize();
            floor.Sprite.Position = new Vector2f(X * Universe.TileSize, Y * Universe.TileSize);
            Floor = floor;
        }
        
        
        public void PlaceMain(Placement main)
        {
            main.Tile = this;
            main.Initialize();
            main.Sprite.Position = new Vector2f(X * Universe.TileSize, Y * Universe.TileSize);
            Main = main;
        }
        
        
        public void PlaceRoof(Placement roof)
        {
            roof.Tile = this;
            roof.Initialize();
            roof.Sprite.Position = new Vector2f(X * Universe.TileSize, Y * Universe.TileSize);
            Roof = roof;
        }

        public virtual void Compute(float dt, float fixedDt)
        {
            Floor?.Compute(dt, fixedDt);
            Main?.Compute(dt, fixedDt);
            Roof?.Compute(dt, fixedDt);
        }
    }
}