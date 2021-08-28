using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SmallTail.TdFactory.Game.States
{
    public abstract class GameState
    {
        public virtual void Initialize(GameCore game)
        {
        }
        
        public virtual void Update(GameTime time)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime time)
        {
        }
    }
}