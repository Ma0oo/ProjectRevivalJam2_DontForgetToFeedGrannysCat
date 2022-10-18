using System;
using System.Collections.Generic;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
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
                Added?.Invoke(item);
            }
            return r;
        }

        public bool Remove(Item item)
        {
            var r = ItemsContaints.Remove(item);
            if(r) Removed?.Invoke(item);
            return r;
        }

        public abstract bool ValidateAdd(Item item);
    }
}