using DefaultNamespace.ItemSystem;
using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;
using UltEvents;

namespace DefaultNamespace.Player.Inventory.HandView.ExtInterect
{
    public class ExtHandInterectObjeect : BaseExtInterectObject
    {
        public UltEvent<Item> Used;
        
        protected override void OnInterected(InterectActionBase obj)
        {
            TryCast<HandActionInterect>(obj, x =>
            {
                if(x._item!=null) Used.Invoke(x._item);
            });
        }
    }
}