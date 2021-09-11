namespace TdFactory.Core.System
{
    public abstract class GameState : IComputer, IUpdater, IRenderer
    {
        public virtual void Initialize(Game game) {}
        
        public virtual void Compute(float dt, float fixedDt) {}
        
        public virtual void Update(float dt) {}
        
        public virtual void Render(float dt) {}
    }
}