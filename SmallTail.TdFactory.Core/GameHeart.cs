using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SmallTail.TdFactory.Core.Modding;

namespace SmallTail.TdFactory.Core
{
    public class GameHeart : Game
    {
        private GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;
        private GameState _state;

        public GameHeart()
        {
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
        }

        public void SetState(GameState state)
        {
            state.Initialize(this);
            
            _state = state;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SetState(new ModLoadingState());

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _state.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            
            _state.Draw(_spriteBatch, gameTime);
            
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}