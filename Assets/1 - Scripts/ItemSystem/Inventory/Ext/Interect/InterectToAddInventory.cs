using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;
using UltEvents;
using UnityEngine;

namespace DefaultNamespace.ItemSystem.Inventory.Ext.Interect
{
    public class InterectToAddInventory : BaseExtInterectObject
    {
        [SerializeField] private IViewItem _view;
        
        public UltEvent AddedToInventory;
        
        protected override void OnInterected(InterectActionBase obj)
        {
            TryCast<AddToInventory>(obj, x =>
            {
                if(x.Inventory.Add(_view.Item)) AddedToInventory?.Invoke();
            });
        }
    }
}