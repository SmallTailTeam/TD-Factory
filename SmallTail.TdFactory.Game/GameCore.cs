using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Serilog;
using SmallTail.TdFactory.Game.States;

namespace SmallTail.TdFactory.Game
{
    public class GameCore : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;
        private GameState _state;

        public GameCore()
        {
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
        }

        public void SetState(GameState state)
        {
            Log.Information("Game state changed to {0}", state);
            
            _state = state;
            
            state.Initialize(this);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            SetState(new InitializationState());
        }

        protected override void Update(GameTime gameTime)
        {
            _state.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            
            _state.Draw(_spriteBatch, gameTime);
            
            _spriteBatch.End();
        }
    }
}