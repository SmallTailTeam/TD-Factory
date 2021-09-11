using SFML.Graphics;
using SFML.System;
using TdFactory.Core.Entities;
using TdFactory.Core.Mathematics;
using TdFactory.Core.System;
using TdFactory.Core.UI;
using TdFactory.Core.World;
using TdFactory.Core.World.Tiles;
using TdFactory.Core.World.Tiles.Placements;

namespace TdFactory.Core
{
    public class TestingState : GameState
    {
        private Player _player;
        private InventoryRenderer _inventoryRenderer;
        private Text _fpsText;

        public override void Initialize(Game game)
        {
            _player = new Player();
            _inventoryRenderer = new InventoryRenderer(_player.Inventory);

            Font font = new ("Assets/Fonts/SegoeUI.ttf");
            _fpsText = new Text
            {
                Font = font
            };

            for (int x = -Universe.HalfSize; x < Universe.HalfSize; x++)
            {
                for (int y = -Universe.HalfSize; y < Universe.HalfSize; y++)
                {
                    float noise = Noise.CalcPixel2D(x, y, 20.5423f);

                    if (noise > 210f)
                    {
                        Tile tile = Universe.Tilemap.GetTile(x, y);
                        tile.PlaceMain(new TreePlacement());
                    }
                }
            }
            
            for (int x = -Universe.HalfSize; x < Universe.HalfSize; x++)
            {
                for (int y = -Universe.HalfSize; y < Universe.HalfSize; y++)
                {
                    float noise = Noise.CalcPixel2D(x, y, 20.5423f);

                    if (noise > 240f)
                    {
                        Tile tile = Universe.Tilemap.GetTile(x, y);
                        tile.PlaceMain(new RockPlacement());
                    }
                }
            }
        }

        public override void Compute(float dt, float fixedDt)
        {
            _player.Compute(dt, fixedDt);
            
            Universe.Tilemap.Compute(dt, fixedDt);
        }

        public override void Update(float dt)
        {
            _player.Update(dt);

            _fpsText.DisplayedString = $"FPS: {1f/dt}";
            _fpsText.Position = Game.Window.MapPixelToCoords(new Vector2i(0, 0));
        }

        public override void Render(float dt)
        {
            Universe.Tilemap.Render(dt);
            
            Game.Window.Draw(_player.Sprite);
            
            Game.Window.Draw(_fpsText);
            _inventoryRenderer.Render(dt);
        }
    }
}