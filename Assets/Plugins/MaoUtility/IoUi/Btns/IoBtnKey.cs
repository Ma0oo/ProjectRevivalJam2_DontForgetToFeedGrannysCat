using System;
using Lean.Gui;
using TMPro;
using UnityEngine;

namespace Plugins.MaoUtility.IoUi.Btns
{
    public class IoBtnKey : IOBtn<KeyCode>
    {
        public override event Action<KeyCode, IOBtn<KeyCode>> Updated;

        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private LeanButton _btn;

        private State _state;
        
        private Func<KeyCode> _get;
        private Action<KeyCode> _set;

        public override void SetWithoutEvent(KeyCode value)
        {
            _label.text = value.ToString();
        }

        public override void Init(Func<KeyCode> get, Action<KeyCode> set)
        {
            _get = get;
            _set = set;
            SetWithoutEvent(get());
            ChangeState(new NoneSelected(this));
        }

        private void Update() => _state?.Update();

        private void ChangeState(State s)
        {
            if (_state!=null)
            {
                _state?.Exit();
                _state.ChangeTo -= ChangeState;
            }
            _state = s;
            if (_state!=null)
            {
                _state?.Enter();
                _state.ChangeTo += ChangeState;
            }
            
        }

        private abstract class State
        {
            public abstract event Action<State> ChangeTo;

            public IoBtnKey Btn { get; private set; }

            public State(IoBtnKey btn) => Btn = btn;

            public abstract void Enter();
            public abstract void Update();
            public abstract void Exit();
        }
        
        private class NoneSelected : State
        {
            public NoneSelected(IoBtnKey btn) : base(btn) { }

            public override event Action<State> ChangeTo;
            public override void Enter()
            {
                Btn._btn.OnClick.AddListener(OnClick);    
                Btn.SetWithoutEvent(Btn._get());
            }

            public override void Update() { }

            public override void Exit() => Btn._btn.OnClick.RemoveListener(OnClick);

            private void OnClick() => ChangeTo?.Invoke(new Selected(Btn));
        }
        
        private class Selected : State
        {
            public Selected(IoBtnKey btn) : base(btn) { }

            public override event Action<State> ChangeTo;
            public override void Enter()
            {
                Btn._label.text = "...";
            }

            public override void Update()
            {
                foreach (KeyCode key in (KeyCode[])Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(key))
                    {
                        Btn._set(key);
                        Btn.SetWithoutEvent(Btn._get());
                        Btn.Updated?.Invoke(Btn._get(), Btn);
                        ChangeTo?.Invoke(new NoneSelected(Btn));
                    }
                }
            }

            public override void Exit()
            {
                
            }
        }
    }
}