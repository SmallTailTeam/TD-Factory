using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SmallTail.TdFactory.Core
{
    public abstract class GameState
    {
        public virtual void Initialize(GameHeart game)
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