using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;
using Sirenix.OdinInspector;
using UltEvents;
using UnityEngine;

namespace Plugins.MaoUtility.InterectSystem.Implementation.RayView
{
    public class RayViewObject : BaseExtInterectObject
    {
        [ShowInInspector, ReadOnly] private bool _state = false;
        [SerializeField] private bool _offEventOnStart = true;
        
        public UltEvent ToOn;
        public UltEvent ToOff;

        protected override void Start()
        {
            base.Start();
            if(_offEventOnStart) ToOff?.Invoke();
        }

        protected override void OnInterected(InterectActionBase obj)
        {
            TryCast<RayAction>(obj, TryUpdateState);
        }

        [Button]
        private void TryUpdateState(RayAction obj)
        {
            if(_state==obj.State) return;
            _state = obj.State;
            if(_state) ToOn?.Invoke();
            else ToOff?.Invoke();
        }
    }
}