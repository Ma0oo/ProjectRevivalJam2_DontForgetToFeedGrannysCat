using System;
using DefaultNamespace.ApartmentSystem;
using NoSystem;
using Plugins.MaoUtility.Attributes;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.MaoExts.Static;
using UltEvents;
using UnityEngine;

namespace DoorSystem
{
    [RequireComponent(typeof(DoorEdit)), DiMark]
    public class Door : MonoBehaviour, IRoomPart
    {
        [DiInject(RegisterDoor.IdFadeScreen)] private FadeScreen Fade;

        public Door ConnectDoor => _connectDoor;
        [SerializeField] private Door _connectDoor;
        [SerializeField] private Transform _pointExit;

        public bool IsBlock => _isBlock;
        [SerializeField] private bool _isBlock;

        public UltEvent Blocked;
        public UltEvent Unblocked;
        
        public UltEvent Open;
        public UltEvent Close;

        public event Action StartMove;
        public event Action EndMove;

        public void SetBlock(bool isActive)
        {
            if (isActive == IsBlock) return;
            _isBlock = isActive;
            if (_isBlock) Blocked.Invoke();
            else Unblocked.Invoke();
        }


        public bool MakeMove(DoorMoveEntity entity)
        {
            if (_connectDoor == null || IsBlock) return false;
            if (_connectDoor.IsBlock) return false;
            Open?.Invoke();
            StartMove?.Invoke();
            entity.SetStateMove(true);

            Fade.Transition(() =>
            {
                entity.transform.position = _connectDoor._pointExit.transform.position;
                entity.transform.rotation = _connectDoor._pointExit.transform.rotation;
                Close?.Invoke();
                EndMove?.Invoke();
                entity.SetStateMove(false);
            });
            return true;
        }

        private void OnDrawGizmosSelected() => TryDrawGizmos();

        private void OnDrawGizmos() => 
            this.With(DoorConfig.ShowAllwaysGizmos, x => TryDrawGizmos());

        private void TryDrawGizmos()
        {
            if(_connectDoor==null) return;
            DoorConfig Config=DoorConfig.Instance;
            Gizmos.color = Config.ColorLine;
            var midPoint = Vector3.Lerp(transform.position, _connectDoor.transform.position, 0.5f);
            midPoint.y += Config.HLine;
            Gizmos.DrawLine(transform.position, midPoint);
        }

        public void Connect(Door door)
        {
            if (_connectDoor != null && _connectDoor != door) Disconect();
            if(_connectDoor==door) return;
            _connectDoor = door;
            door.Connect(this);
        }

        public void Disconect()
        {
            if(_connectDoor==null) return;
            var preConnect = _connectDoor;
            _connectDoor = null;
            preConnect.Disconect();
        }
    }
}