using UnityEngine;

namespace DefaultNamespace.ItemSystem.Inventory
{
    public class BaseMonoInventory : MonoBehaviour, IMonoInventory
    {
        [SerializeReference] private InventoryBase _inventory;
        
        public bool Add(Item item) => _inventory.Add(item);

        public bool Remove(Item item) => _inventory.Remove(item);
    }
}