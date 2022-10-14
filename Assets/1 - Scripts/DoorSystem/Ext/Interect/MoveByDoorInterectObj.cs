using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace DoorSystem.Ext.Interect
{
    public class MoveByDoorInterectObj : BaseExtInterectObject
    {
        [SerializeField] private Door _door;

        private static bool InMove;
        private MoveByDoorAction _action;
        [ShowInInspector, ReadOnly] private bool _inMove=>InMove;

        protected override void Start()
        {
            base.Start();
            InMove = false;
        }

        protected override void OnInterected(InterectActionBase obj)
        {
            if(InMove || _door==null) return;
            TryCast<MoveByDoorAction>(obj, x => _action = x);
            if(_action==null) return;
            _door.StartMove += OnStartMove;
            _door.EndMove += OnEndMove;
            if(!_door.MakeMove(_action.MoveObj)) OnEndMove();
        }

        private void OnStartMove()
        {
            InMove = true;
        }

        private void OnEndMove()
        {
            InMove = false;
            _door.StartMove -= OnStartMove;
            _door.EndMove -= OnEndMove;
            _action = null;
        }
    }
}