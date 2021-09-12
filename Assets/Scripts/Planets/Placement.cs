using System;
using TdFactory.System;

namespace TdFactory.Planets
{
    public class Placement : IInteractable
    {
        public Action CleanedUp { get; set; }
        
        public Tile MainTile;
        public Tile[] Tiles;

        public virtual void Initialize() {}
        
        public virtual void Tick() {}

        public virtual void CleanUp()
        {
            CleanedUp?.Invoke();
        }
        
        public virtual void Interact(Interaction interaction) { }
    }
}