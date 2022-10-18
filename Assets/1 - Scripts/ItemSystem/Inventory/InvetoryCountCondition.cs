using UnityEngine;

namespace DefaultNamespace.ItemSystem.Inventory
{
    public class InvetoryCountCondition : InventoryBase
    {
        [SerializeField, UnityEngine.Min(1)] private int MaxCount;
        
        public override bool ValidateAdd(Item item) => Items.Count < MaxCount;
    }
}