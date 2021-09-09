using SFML.Graphics;
using SFML.System;
using TdFactory.Core.Graphics;

namespace TdFactory.Core.World
{
    public class Chunk
    {
        private static Texture _square = Shapes.Square(128, 128, Color.White);

        public Vector2i Position;
        public Sprite[,] Tiles = new Sprite[WorldRules.CHUNK_SIZE, WorldRules.CHUNK_SIZE];

        public Chunk(Vector2i position)
        {
            Position = position;
            
            for (int x = 0; x < WorldRules.CHUNK_SIZE; x++)
            {
                for (int y = 0; y < WorldRules.CHUNK_SIZE; y++)
                {
                    Vector2f tilePosition = new (
                        position.X * WorldRules.CHUNK_SIZE * WorldRules.TILE_SIZE + x * WorldRules.TILE_SIZE,
                        position.Y * WorldRules.CHUNK_SIZE * WorldRules.TILE_SIZE + y * WorldRules.TILE_SIZE);
                    
                    Tiles[x, y] = new Sprite
                    {
                        Texture = _square,
                        Color = Color.Green,
                        Position = tilePosition
                    };
                }
            }
        }
    }
}