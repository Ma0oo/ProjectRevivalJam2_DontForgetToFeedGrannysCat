using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace DefaultNamespace.ItemSystem
{
    [CreateAssetMenu(menuName = "Game/ItemSo")]
    public class ItemSo : SerializedScriptableObject
    {
        public Item ClonedItem => _item.Clone();
        [SerializeField] private Item _item;
    }
}