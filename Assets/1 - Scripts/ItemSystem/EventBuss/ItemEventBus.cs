using Plugins.MaoUtility.AdvanceEvents.EventsBus;

namespace DefaultNamespace.ItemSystem.EventBuss
{
    public class ItemEventBus : ItemConfig
    {
        public Bus BusE => _bus != null ? _bus : _bus = new Bus();
        private Bus _bus;
        
        public override object Clone() => new ItemEventBus();
        
        public class Bus : EventBusLimited<IItemEvent>
        {
            
        }
        
        public interface IItemEvent
        {
            
        }
    }
}