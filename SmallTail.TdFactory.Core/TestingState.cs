using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SmallTail.TdFactory.Core.Graphics;

namespace SmallTail.TdFactory.Core
{
    public class TestingState : GameState
    {
        private const uint TILESIZE = 128;
        private const uint MAPSIZE = 5;

        private Game _game;
        private List<Sprite> _tiles = new();

        public override void Initialize(Game game)
        {
            _game = game;
            
            Texture grass = Shapes.Square(TILESIZE, TILESIZE, Color.Green);

            for (int x = 0; x < MAPSIZE; x++)
            {
                for (int y = 0; y < MAPSIZE; y++)
                {
                    Sprite tile = new()
                    {
                        Texture = grass,
                        Position = new Vector2f(x * TILESIZE, y * TILESIZE)
                    };
                    
                    _tiles.Add(tile);
                }
            }
        }

        public override void Render(float dt)
        {
            foreach (Sprite tile in _tiles)
            {
                _game.Window.Draw(tile);
            }
        }
    }
}