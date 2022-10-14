using System;
using System.Collections.Generic;
using UnityEngine;

namespace Plugins.MaoUtility.SM
{
    public abstract class SmByStruct<T> : SmBase<T> where T : struct
    {
        public override T Current => _current.HasValue ? _current.Value : _defaultState;
        
        public override event Action<T> ExitFrom;
        public override event Action<T> EnterTo;
        public override event Action<T, T> FailedChange;

        
        [SerializeField] private T? _current;
        [SerializeField] private T _defaultState;
        
        public override void ChangeTo(T newState)
        {
            if (_current.HasValue)
            {
                var preState = _current.Value;
                if (!ValidChange(preState, newState))
                {
                    FailedChange?.Invoke(preState, newState);
                    return;
                }
                ExitFrom?.Invoke(preState);
                _current = newState;
                EnterTo?.Invoke(newState);
            }
            else
            {
                _current = newState;
                EnterTo?.Invoke(newState);
            }
        }

        public override bool ValidChange(T oldState, T newState) 
            => EqualityComparer<T>.Default.Equals(oldState, newState);
    }
}