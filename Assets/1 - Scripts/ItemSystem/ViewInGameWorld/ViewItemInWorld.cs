using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.ItemSystem.ViewInGameWorld
{
    public class ViewItemInWorld : MonoBehaviour, IViewItem
    {
        [ShowInInspector, HideLabel] private Item _item;

        public Item Item => _item;
        public event Action<Item> Inited;
        
        public void Init(Item item)
        {
            _item = item;
            Inited?.Invoke(item);
        }
        
        public class ViewItemInWorld_CFG : ItemConfig
        {
            public ViewItemInWorld View => _view;
            [SerializeField] private ViewItemInWorld _view;
            
            public override object Clone()
            {
                var r = new ViewItemInWorld_CFG();
                r._view = _view;
                return r;
            }
        }
    }
}