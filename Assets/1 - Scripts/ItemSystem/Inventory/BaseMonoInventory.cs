using System;
using System.Collections.Generic;
using DefaultNamespace.Player.Inventory;
using UnityEngine;

namespace DefaultNamespace.ItemSystem.Inventory
{
    public class BaseMonoInventory : MonoBehaviour, IPlayerInventory
    {
        [SerializeReference] private InventoryBase _inventory;

        public IReadOnlyCollection<Item> Items => _inventory.Items;

        public event Action<Item> Added
        {
            add => _inventory.Added += value;
            remove => _inventory.Added -= value;
        }

        public event Action<Item> Removed
        {
            add => _inventory.Removed += value;
            remove => _inventory.Removed -= value;
        }

        public bool Add(Item item) => _inventory.Add(item);

        public bool Remove(Item item) => _inventory.Remove(item);
    }
}