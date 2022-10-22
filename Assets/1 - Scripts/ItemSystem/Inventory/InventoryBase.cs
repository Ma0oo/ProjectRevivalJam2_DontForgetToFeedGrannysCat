using System;
using System.Collections.Generic;
using DefaultNamespace.ItemSystem.EventBuss;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.OdinInspector;
using UnityEngine.Rendering.PostProcessing;

namespace DefaultNamespace.ItemSystem.Inventory
{
    [System.Serializable]
    public abstract class InventoryBase : IInventory
    {
        [ShowInInspector] protected HashSet<Item> ItemsContaints = new HashSet<Item>();

        public IReadOnlyCollection<Item> Items => ItemsContaints;
        public event Action<Item> Added;
        public event Action<Item> Removed;

        public bool Add(Item item)
        {
            var r = ValidateAdd(item);
            if (r)
            {
                ItemsContaints.Add(item);
                SubAction(item.OpenConfig.GetOrCreate<ItemEventBus>(), true, item);
                Added?.Invoke(item);
            }
            return r;
        }

        private void SubAction(ItemEventBus bus, bool b, Item item)
        {
            if(b) bus.BusE.Sub<RemoveItemEvent>(OnRemove);
            else bus.BusE.Unsub<RemoveItemEvent>(OnRemove);

            void OnRemove(RemoveItemEvent e)
            {
                Remove(item);
            }
        }

        public bool Remove(Item item)
        {
            var r = ItemsContaints.Remove(item);
            if (r)
            {
                SubAction(item.OpenConfig.GetOrCreate<ItemEventBus>(), false, item);
                Removed?.Invoke(item);
            }
            return r;
        }

        public abstract bool ValidateAdd(Item item);
        
        public class RemoveItemEvent : ItemEventBus.IItemEvent
        {
            
        }
    }
}