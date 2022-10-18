using Plugins.MaoUtility.DataManagers;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.ItemSystem
{
    [System.Serializable]
    public class Item
    {
        public ICloseDataManager<ItemConfig> Confgis => _itemConfigManager;
        [SerializeField] private ItemConfigManager _itemConfigManager;

        public Item Clone()
        {
            var r = new Item();
            r._itemConfigManager = _itemConfigManager.Clone() as ItemConfigManager;
            return r;
        }
    }
}