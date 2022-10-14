using System;
using System.Collections.Generic;
using Lean.Gui;
using Plugins.MaoUtility.MonoBehsGameHelper.UI;
using Plugins.MaoUtility.SceneFlow;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ScenesLogic.Menu
{
    public class PanelMenu : SceneLogic
    {
        [SerializeField] private PanelUI _main;
        [SerializeField] private PanelUI _setting;
        [SerializeField] private PanelUI _credit;

        public State DefaultState;

        [ShowInInspector, ReadOnly]private State? _current;
        [ShowInInspector, ReadOnly]private Stack<State> _history = new Stack<State>();

        public event Action<State> ChangeStateFrom;
        public event Action<State> ChangeStateTo;

        private void Awake() => ChangeState(DefaultState);

        public void ChangeState(State newState) => ChangeState(newState, true);

        private void ChangeState(State newState, bool writeHistory)
        {
            State? preState = null;
            if (_current.HasValue)
            {
                GetPanekByState(_current.Value).SetActive(false);
                if(writeHistory) _history.Push(_current.Value);
                preState = _current.Value;
            }
            _current = newState;
            ChangeStateFrom?.Invoke(preState.Value);
            GetPanekByState(_current.Value).SetActive(true);
            ChangeStateTo?.Invoke(newState);
        }

        public void GoBack()
        {
            if(!_history.TryPop(out var r)) return;
            if(r!=_current.Value) ChangeState(r, false);
        }

        private PanelUI GetPanekByState(State s)
        {
            if (s == State.Main) return _main;
            else if (s == State.Setting) return _setting;
            return _credit;
        }
        
        public enum State
        {
            Main, Setting, Credit
        }
    }
}

