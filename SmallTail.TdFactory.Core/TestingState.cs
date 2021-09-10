using SFML.Graphics;
using TdFactory.Core.Graphics;
using TdFactory.Core.Mathematics;
using TdFactory.Core.World;
using TdFactory.Core.World.Tiles;

namespace TdFactory.Core
{
    public class TestingState : GameState
    {
        private Player _player;

        public override void Initialize(Game game)
        {
            _player = new Player();

            Texture grass = Shapes.Square(128, 128, Color.White);
            
            for (int x = -Universe.HalfSize; x < Universe.HalfSize; x++)
            {
                for (int y = -Universe.HalfSize; y < Universe.HalfSize; y++)
                {
                    Tile tile = Universe.Tilemap.GetTile(x, y);
                    tile.Sprite.Texture = grass;

                    float a = Noise.CalcPixel2D(x, y, 1000);

                    tile.Sprite.Color = new Color(0, (byte)(200 + a * 0.1), 0);
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

            Game.Window.SetTitle($"FPS: {1f/dt}");
        }

        public override void Render(float dt)
        {
            Universe.Tilemap.Render(dt);
            
            Game.Window.Draw(_player.Sprite);
        }
    }
}