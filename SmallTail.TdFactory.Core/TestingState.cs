using SFML.Graphics;
using TdFactory.Core.World;

namespace TdFactory.Core
{
    public class TestingState : GameState
    {
        private Game _game;

        private Player _player;
        private Tilemap _tilemap;

        public override void Initialize(Game game)
        {
            _game = game;

            _player = new Player();
            _tilemap = new Tilemap();
        }

        public override void Update(float dt)
        {
            _player.Update(dt);
            _tilemap.UpdateVisibleChunks(_player.Sprite.Position);
            
            _game.Window.SetTitle($"FPS: {1f/dt}");
        }

        public override void Render(float dt)
        {
            foreach (Chunk chunk in _tilemap.Chunks)
            {
                foreach (Sprite tile in chunk.Tiles)
                {
                    _game.Window.Draw(tile);
                }
            }

            _game.Window.Draw(_player.Sprite);
        }
    }
}