using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SmallTail.TdFactory.Core.Entities
{
    public  class EntityRenderer : EntityComponent
    {
        public Texture2D Texture;
        
        public override void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(Texture, Target.Position, Color.White);
        }
    }
}