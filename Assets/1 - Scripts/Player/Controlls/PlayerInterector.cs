using DoorSystem;
using DoorSystem.Ext.Interect;
using Player.Input;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.InputModule.AutoSub;
using Plugins.MaoUtility.InputModule.Core;
using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;
using Plugins.MaoUtility.InterectSystem.Implementation;
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
                TryGetInterectObj(info.collider)
                    ?.Interect(new ToggleInterect.InvertState())
                    .Interect(new MoveByDoorAction(_doorMoveEntity));
        }
    }
}