using System;
using UnityEngine;

namespace Plugins.MaoUtility.SM
{
    public class SmByClass<T> : SmBase<T> where T : class, IStateSm
    {
        public override T Current => _current;
        
        public override event Action<T> ExitFrom;
        public override event Action<T> EnterTo;
        public override event Action<T, T> FailedChange;

        [SerializeField] private T _current;
        
        public override void ChangeTo(T newState)
        {
            if (_current != null)
            {
                if (!ValidChange(_current, newState))
                {
                    FailedChange?.Invoke(_current, newState);
                    return;
                }
                _current.Exit();
                ExitFrom.Invoke(_current);
                
                _current = newState;
                _current.Enter();
                EnterTo?.Invoke(_current);
            }
            else
            {
                _current = newState;
                EnterTo?.Invoke(_current);
            }
        }

        public override bool ValidChange(T oldState, T newState) => oldState != newState;
    }
}