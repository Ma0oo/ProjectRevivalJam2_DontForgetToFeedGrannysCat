using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;
using UltEvents;
using UnityEngine;

namespace Plugins.MaoUtility.InterectSystem.Implementation
{
    public class ToggleInterect : BaseExtInterectObject
    {
        [SerializeField] private bool _state;
        [SerializeField] private bool _invokeOnStart;

        public UltEvent IsOn;
        public UltEvent IsOff;

        protected override void Start()
        {
            base.Start();
            if(_invokeOnStart) InvokeEvent();
        }

        protected override void OnInterected(InterectActionBase obj)
        {
            TryCast<ChangeStateAt>(obj, ChangeState);
            TryCast<InvertState>(obj, Invert);
        }

        private void Invert(InvertState obj)
        {
            _state = !_state;
            InvokeEvent();
        }

        private void ChangeState(ChangeStateAt obj)
        {
            if(_state==obj.ChangeTo) return;
            _state = obj.ChangeTo;
            InvokeEvent();
        }

        private void InvokeEvent()
        {
            if(_state) IsOn.Invoke();
            else IsOff.Invoke();
        }
        
        public class ChangeStateAt : InterectActionBase
        {
            public bool ChangeTo { get; private set; }

            public ChangeStateAt(bool cahngeTo)
            {
                ChangeTo = cahngeTo;
            }
        }
        
        public class InvertState : InterectActionBase
        {
            
        }
    }
}