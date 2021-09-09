using SFML.System;
using TdFactory.Core.Mathematics;

namespace TdFactory.Core.World
{
    public class Tilemap
    {
        public Chunk[,] Chunks = new Chunk[WorldRules.RENDER_DISTANCE * 2, WorldRules.RENDER_DISTANCE * 2];

        public void UpdateVisibleChunks(Vector2f position)
        {
            for (int x = -WorldRules.RENDER_DISTANCE; x < WorldRules.RENDER_DISTANCE; x++)
            {
                for (int y = -WorldRules.RENDER_DISTANCE; y < WorldRules.RENDER_DISTANCE; y++)
                {
                    Vector2i chunkPosition = new (
                        Calc.RoundToInt(position.X / WorldRules.CHUNK_SIZE / WorldRules.TILE_SIZE) + x,
                        Calc.RoundToInt(position.Y/ WorldRules.CHUNK_SIZE / WorldRules.TILE_SIZE) + y
                        );

                    Chunk chunk = GetChunkAt(chunkPosition);

                    if (chunk == null)
                    {
                        Chunks[x + WorldRules.RENDER_DISTANCE, y + WorldRules.RENDER_DISTANCE] = new Chunk(chunkPosition);
                    }
                }
            }
        }

        public Chunk GetChunkAt(Vector2i position)
        {
            foreach (Chunk chunk in Chunks)
            {
                if (chunk != null && chunk.Position == position)
                {
                    return chunk;
                }
            }
            
            return null;
        }
    }
}