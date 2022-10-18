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
    }
}