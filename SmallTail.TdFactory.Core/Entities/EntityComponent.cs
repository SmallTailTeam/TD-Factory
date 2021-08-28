using Microsoft.Xna.Framework;
using SmallTail.TdFactory.Core.Networking;

namespace SmallTail.TdFactory.Core.Entities
{
    public abstract class EntityComponent : Networked
    {
        public Entity Target;

        public abstract void Update(GameTime gameTime);
    }
}