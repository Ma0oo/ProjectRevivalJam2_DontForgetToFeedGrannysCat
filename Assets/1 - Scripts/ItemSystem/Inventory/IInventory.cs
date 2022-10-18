using System;
using System.Collections.Generic;

namespace DefaultNamespace.ItemSystem.Inventory
{
    public interface IInventory
    {
        public IReadOnlyCollection<Item> Items { get; }
        
        public event Action<Item> Added;
        public event Action<Item> Removed;
        
        bool Add(Item item);
        bool Remove(Item item);
    }
}