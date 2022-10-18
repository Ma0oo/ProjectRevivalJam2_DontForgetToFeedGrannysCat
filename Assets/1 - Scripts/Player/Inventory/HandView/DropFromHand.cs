using DefaultNamespace.ItemSystem.ViewInGameWorld;
using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.InputModule.AutoSub;
using UnityEngine;

namespace DefaultNamespace.Player.Inventory.HandView
{
    public class DropFromHand : MonoBehaviour
    {
        [SerializeField] private Transform _rootPoint;
        [SerializeField] private HandView _handView;

        private SubInputInterface<IHandInput> _input;

        private void Start()
        {
            _input = new SubInputInterface<IHandInput>(x=>x.DropSelected+=OnDrop, x=>x.DropSelected-=OnDrop);
            _input.SubscribeAction(true);
        }

        private void OnDrop()
        {
            if(_handView.SelectedItem==null) return;
            var item = _handView.SelectedItem;
            if(_handView.Inventory.Remove(_handView.SelectedItem)==false) return;
            _handView.SelectLastIndex();
            var cfg=item.Confgis.Get<ViewItemInWorld.ViewItemInWorld_CFG>();
            if(cfg==null) return;
            var r = cfg.View.SpawnWithDi(DI.Instance);
            r.transform.position = _rootPoint.transform.position;
            r.Init(item);
        } 
    }
}