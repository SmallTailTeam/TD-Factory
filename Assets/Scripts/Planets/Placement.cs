using System;
using TdFactory.System;

namespace TdFactory.Planets
{
    public class Placement : IInteractable
    {
        public Action CleanedUp { get; set; }
        
        public Tile ParentTile;

        public virtual void Initialize() {}
        
        public virtual void PhysicsTick() {}
        
        public virtual void Tick() {}

        public virtual void CleanUp()
        {
            CleanedUp?.Invoke();
        }
        
        public virtual void Interact(Interaction interaction) { }
    }
}