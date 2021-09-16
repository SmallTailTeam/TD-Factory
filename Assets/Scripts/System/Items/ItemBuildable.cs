using TdFactory.Planets;

namespace TdFactory.System.Items
{
    public interface IBuildable
    {
        void Build(Tile tile);
    }
    
    public class ItemBuildable<T> : Item, IBuildable where T : Placement, new()
    {
        public void Build(Tile tile)
        {
            tile.SetThing<T>();
        }
    }
}