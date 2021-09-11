using SFML.Graphics;
using TdFactory.Core.Entities;
using TdFactory.Core.System;

namespace TdFactory.Core.World.Tiles.Placements
{
    public class Placement : IComputer
    {
        public Sprite Sprite;
        public Tile Tile;
        public bool Obscuring;
        
        public virtual void Initialize() {}
        
        public virtual void Interact(Player player) {}
        
        public virtual void Compute(float dt, float fixedDt) { }
    }
}