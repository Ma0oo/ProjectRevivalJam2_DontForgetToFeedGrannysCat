using System;
using System.Linq;
using DefaultNamespace.ItemSystem;
using DefaultNamespace.ItemSystem.Inventory;
using DefaultNamespace.Player.Inventory.HandView.ExtInterect;
using NoSystem;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.InputModule.AutoSub;
using Plugins.MaoUtility.InputModule.Core;
using Plugins.MaoUtility.InterectSystem.Core;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.Player.Inventory.HandView
{
    [DiMark]
    public class HandView : SerializedMonoBehaviour, IPlayerUnitPart
    {
        public IMonoInventory Inventory => _inventory;
        [SerializeField] private IMonoInventory _inventory;

        public Item SelectedItem { get; private set; }
        private SubInputInterface<IHandInput> _input;
        private HandViewModel _currentView;
        private int _lastIndex;

        private void Start()
        {
            _input = new SubInputInterface<IHandInput>(Reg, Unreg);
            _input.SubscribeAction(true);
            _inventory.Removed += x => SelectLastIndex();
        }

        public void SelectLastIndex() => OnSelected(_lastIndex);

        private void OnSelected(int obj)
        {
            _lastIndex = obj;
            var items = _inventory.Items.ToArray();
            Debug.Log($"Отработка - {items.Length}");
            if (_currentView != null)
            {
                _currentView?.DeleteGO();
                _currentView = null;
            }

            if (obj < items.Length)
                SelectedItem = items[obj];
            else
                SelectedItem = null;
            if (SelectedItem != null)
            {
                var cfg = SelectedItem.Confgis.Get<HandViewModel.HandViewModel_CFG>();
                if(cfg==null) return;
                (_currentView = cfg.PrefabModel.Spawn(transform)).Init(SelectedItem);
            }            
        }

        private void Reg(IHandInput obj) => obj.Select += OnSelected;

        private void Unreg(IHandInput obj) => obj.Select -= OnSelected;
    }
}