namespace SmallTail.TdFactory.Core
{
    public abstract class GameState
    {
        public virtual void Initialize(Game game) {}
        
        public virtual void Update(float dt) {}
        
        public virtual void Render(float dt) {}
    }
}