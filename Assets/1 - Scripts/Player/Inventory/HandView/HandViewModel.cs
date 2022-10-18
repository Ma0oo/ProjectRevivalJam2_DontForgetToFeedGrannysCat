using System;
using DefaultNamespace.ItemSystem;
using UnityEngine;

namespace DefaultNamespace.Player.Inventory.HandView
{
    public class HandViewModel : MonoBehaviour, IViewItem
    {
        private Item _item;

        public void Init(Item item)
        {
            _item = item;
            Inited?.Invoke(item);
        }

        public Item Item => _item;
        public event Action<Item> Inited;
        
        [System.Serializable]
        public class HandViewModel_CFG : ItemConfig
        {
            public HandViewModel PrefabModel => _prefabModel;
            [SerializeField] private HandViewModel _prefabModel;
            
            public override object Clone()
            {
                var r = new HandViewModel_CFG();
                r._prefabModel = PrefabModel;
                return r;
            }
        }
    }
}