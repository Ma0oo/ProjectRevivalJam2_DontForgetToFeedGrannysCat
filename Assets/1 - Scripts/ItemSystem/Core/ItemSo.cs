using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.ItemSystem
{
    [CreateAssetMenu(menuName = "Games/ItemSo")]
    public class ItemSo : ScriptableObject
    {
        public Item ClonedItem => _item.Clone();
        [SerializeField, HideLabel] private Item _item;
    }
}