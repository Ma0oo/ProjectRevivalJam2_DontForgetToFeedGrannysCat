using DefaultNamespace.ItemSystem;
using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;

namespace DefaultNamespace.Player.Inventory.HandView.ExtInterect
{
    public class HandActionInterect : InterectActionBase
    {
        public Item _item;

        public HandActionInterect(Item item) => _item = item;
    }
}