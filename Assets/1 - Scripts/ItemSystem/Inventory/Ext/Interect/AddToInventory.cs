using ParadoxNotion;
using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;

namespace DefaultNamespace.ItemSystem.Inventory.Ext.Interect
{
    public class AddToInventory : InterectActionBase
    {
        public IMonoInventory Inventory;

        public AddToInventory(IMonoInventory inventory) => Inventory = inventory;
    }
}
