using System;
using DefaultNamespace.ItemSystem.Inventory;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using Unity.Collections;
using UnityEngine;

namespace DefaultNamespace.ItemSystem.ViewInUI
{
    public class ViewInventory : MonoBehaviour
    {
        [SerializeField] private ViewItemInUI _viewPrefab;
        [SerializeField, Min(1)] private int _countIcons;
        [SerializeField] private Transform _parentTarget;
        [ShowInInspector, Sirenix.OdinInspector.ReadOnly]private ViewItemInUI[] _views;
        private IInventory _invetory;

        private void Start()
        {
            _views =new ViewItemInUI[_countIcons];
            for (int i = 0; i < _countIcons; i++)
            {
                _views[i] = _viewPrefab.Spawn(_parentTarget);
                _views[i].Zero();
            }
        }

        public void Init(IInventory inventory)
        {
            if (_invetory != null)
            {
                _invetory.Added -= OnChanged;
                _invetory.Removed -= OnChanged;
            }
            _invetory = inventory;
            _invetory.Added += OnChanged;
            _invetory.Removed += OnChanged;
            UpdateView();
        }

        private void OnChanged(Item obj) => UpdateView();

        private void UpdateView()
        {
            int count = 0;
            _views.ForEach(x => x.Zero());
            _invetory.Items.ForEach(x =>
            {
                if(count>=_views.Length) return;
                _views[count].Init(x);
                count++;
            });
        }
    }
}