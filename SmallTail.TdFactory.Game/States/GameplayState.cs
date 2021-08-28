using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SmallTail.TdFactory.Core.Entities;
using SmallTail.TdFactory.Game.Entities;

namespace SmallTail.TdFactory.Game.States
{
    public class GameplayState : GameState
    {
        public override void Initialize(GameCore game)
        {
            Player player = Entity.Create<Player>();

            EntityRenderer playerRenderer = new()
            {
                Texture = Texture2D.FromFile(game.GraphicsDevice, "")
            };

            player.AddComponent(playerRenderer);
        }

        public override void Update(GameTime gameTime)
        {
            Entity.ForEach(entity => entity.Update(gameTime));
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Entity.ForEach(entity =>
            {
                foreach (EntityComponent entityComponent in entity.GetComponents())
                {
                    if (entityComponent is EntityRenderer entityRenderer)
                    {
                        entityRenderer.Draw(spriteBatch, gameTime);
                    }
                }
            });
        }
    }
}