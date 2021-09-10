namespace TdFactory.Core.World
{
    public static class Universe
    {
        public const int Size = 100;
        public const int HalfSize = Size / 2;
        public const int TileSize = 90;
        
        public static ITilemap Tilemap = new Tilemap();
    }
}