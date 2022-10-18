using System;
using DefaultNamespace.ItemSystem.Inventory;
using DefaultNamespace.ItemSystem.Inventory.Ext.Interect;
using DoorSystem;
using DoorSystem.Ext.Interect;
using Player.Input;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.InputModule.AutoSub;
using Plugins.MaoUtility.InputModule.Core;
using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;
using Plugins.MaoUtility.InterectSystem.Implementation;
using Plugins.MaoUtility.InterectSystem.Implementation.OneceInterect;
using UnityEngine;

namespace Player.Controlls
{
    [DiMark]
    public class PlayerInterector : BaseInterector
    {
        [DiInject] private InputManager _inputManager;

        [SerializeField] private Transform _point;
        [SerializeField] private float _lenght;
        [SerializeField] private LayerMask _mask;
        [SerializeField] private DoorMoveEntity _doorMoveEntity;
        [SerializeField] private BaseMonoInventory _inventory;

        public event Action NoToInterect;
        public event Action Interected;
        
        private SubInputClass<PlayerInterectInput> _sub;

        private void Start()
        {
            _sub = new SubInputClass<PlayerInterectInput>(
                x =>
                {
                    x.Interect += OnInterect;
                },
                x => x.Interect -= OnInterect,
                _inputManager);
            _sub.SubscribeAction(true);
        }

        private void OnInterect()
        {
            Ray ray = new Ray(_point.transform.position, _point.transform.forward);
            if (Physics.Raycast(ray, out var info, _lenght, _mask)) 
            {
                var interct = TryGetInterectObj(info.collider);
                if (interct)
                {
                    interct
                        .Interect(new ToggleInterect.InvertState())
                        .Interect(new MoveByDoorAction(_doorMoveEntity))
                        .Interect(new OnceInterectAction())
                        .Interect(new AddToInventory(_inventory));
                    Interected?.Invoke();
                }
                else
                    NoToInterect?.Invoke();
            }
            else
            {
                NoToInterect?.Invoke();
            }
        }
    }
}