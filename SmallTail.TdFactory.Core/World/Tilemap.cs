using TdFactory.Core.World.Tiles;

namespace TdFactory.Core.World
{
    public class Tilemap : ITilemap
    {
        private Tile[,] _tiles;

        public Tilemap()
        {
            _tiles = new Tile[Universe.Size, Universe.Size];

            for (int x = -Universe.HalfSize; x < Universe.HalfSize; x++)
            {
                for (int y = -Universe.HalfSize; y < Universe.HalfSize; y++)
                {
                    _tiles[x + Universe.HalfSize, y + Universe.HalfSize] = new Tile(x, y);
                }
            }
        }

        public void Compute(float dt, float fixedDt)
        {
            foreach (Tile tile in _tiles)
            {
                tile.Compute(dt, fixedDt);
            }
        }
        
        public void Render(float dt)
        {
            foreach (Tile tile in _tiles)
            {
                tile.Render(dt);
            }
        }

        public Tile GetTile(int x, int y)
        {
            return _tiles[x + Universe.HalfSize, y + Universe.HalfSize];
        }
    }
}