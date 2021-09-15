using TdFactory.Entities;
using TdFactory.System.Items;
using TdFactory.System.Items.Crafting;

namespace TdFactory.UI.Windows
{
    public class WorkbenchWindow : Window
    {
        public void Craft(string itemId)
        {
            Item item = ItemDefs.Find(itemId);

            if (item != null)
            {
                ItemCraft.Craft(item, Player.Me.Inventory);
            }
        }
    }
}