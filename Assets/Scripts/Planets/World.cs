using TdFactory.Planets.Placements;
using UnityEngine;

namespace TdFactory.Planets
{
    public class World : MonoBehaviour
    {
        public const int SIZE = 100;
        public const int HALF_SIZE = SIZE / 2;
        public const float TILE_SIZE = 0.8f;

        public static World Current;
        
        public Tile[,] Tiles = new Tile[SIZE, SIZE];
        
        private void Awake()
        {
            Current = this;
            
            GenerateMap();
        }

        private void GenerateMap()
        {
            // Generating the tile field:
            for (int x = -HALF_SIZE; x < HALF_SIZE; x++)
            {
                for (int y = -HALF_SIZE; y < HALF_SIZE; y++)
                {
                    GameObject tileGo = new GameObject();
                    tileGo.transform.position = new Vector3(x * TILE_SIZE, y * TILE_SIZE, 1f);
                    tileGo.transform.localScale = new Vector3(TILE_SIZE, TILE_SIZE, 1f);
                    tileGo.transform.parent = transform;

                    BoxCollider2D box = tileGo.AddComponent<BoxCollider2D>();
                    box.isTrigger = true;
                    
                    Tile tile = tileGo.AddComponent<Tile>();
                    tile.Position = new Vector2Int(x, y);
                    tile.World = this;

                    Tiles[x + HALF_SIZE, y + HALF_SIZE] = tile;
                }
            }
            
            // Populating tiles with stuff:
            // Grass:
            foreach (Tile tile in Tiles)
            {
                tile.SetGround<GrassPlacement>();
            }
            
            // Trees:
            foreach (Tile tile in Tiles)
            {
                if (Random.Range(0, 100) > 85)
                {
                    tile.SetThing<TreePlacement>();
                }
            }
            
            // BaseCore:
            Tiles[HALF_SIZE, HALF_SIZE].SetThing<BaseCorePlacement>();
            // Workbench:
            Tiles[HALF_SIZE + 1, HALF_SIZE].SetThing<WorkbenchPlacement>();
        }

        public Tile GetTile(int x, int y)
        {
            x += HALF_SIZE;
            y += HALF_SIZE;

            if (x < 0 || x >= Tiles.GetLength(0) || y < 0 || y >= Tiles.GetLength(1))
            {
                return null;
            }
            
            return Tiles[x, y];
        }

        public Tile GetTile(Vector3 position)
        {
            int x = Mathf.RoundToInt(position.x / TILE_SIZE);
            int y = Mathf.RoundToInt(position.y / TILE_SIZE);
            
            return GetTile(x, y);
        }
    }
}
