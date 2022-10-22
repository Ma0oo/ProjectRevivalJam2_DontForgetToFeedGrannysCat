using System;
using Player.Controlls;
using Plugins.MaoUtility.InterectSystem.Core;
using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;
using UnityEngine;

namespace DefaultNamespace.Player.Inventory.HandView.ExtInterect
{
    public class HandInterect : BaseInterector
    {
        [SerializeField] private HandView _handView;
        [SerializeField] private PlayerInterector _playerInterector;

        private void Start() 
            => _playerInterector.FindedInterect += OnFinded;

        private void OnFinded(InterectObject obj) => obj.Interect(new HandActionInterect(_handView.SelectedItem));
    }
}