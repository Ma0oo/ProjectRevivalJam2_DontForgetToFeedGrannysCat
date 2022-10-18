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
        [ShowInInspector] protected HashSet<Item> Items = new HashSet<Item>();

        public bool Add(Item item)
        {
            var r = ValidateAdd(item);
            if (r) Items.Add(item);
            return r;
        }

        public bool Remove(Item item) => Items.Remove(item);

        public abstract bool ValidateAdd(Item item);
    }
}