using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.ItemSystem.ViewInGameWorld
{
    public class InitItemViewForSO : SerializedMonoBehaviour
    {
        [SerializeField] private IViewItem _viewItem;
        [SerializeField] private ItemSo _soItem;

        private void Start() => _viewItem.Init(_soItem.ClonedItem);

        [Button]private void GetIViewItemOnGM() => _viewItem = GetComponent<IViewItem>();
    }
}