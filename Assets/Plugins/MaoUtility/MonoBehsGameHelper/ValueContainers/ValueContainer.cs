
using System;
using Sirenix.OdinInspector;
using UltEvents;
using UnityEngine;
#if HasAssets_ODIN
#endif

#if HasAssets_UltEvents

#endif

namespace Plugins.MaoUtility.MonoBehsGameHelper.ValueContainers
{
    public abstract class ValueContainer<T> : MonoBehaviour, IValueContainer<T>
    {
        #if HasAssets_ODIN
        [ShowInInspector, ReadOnly]
        #endif
        public T Min => _getMin==null ? _min : _getMin();
        
        [SerializeField] private T _min;
        
        #if HasAssets_ODIN
        [ShowInInspector, ReadOnly]
        #endif
        public T Max => _getMax == null ? _max : _getMax();
        [SerializeField] private T _max;

        private Func<(T min, T max, T oldV, T newV), T> _valid;
        private Func<T> _getMin;
        private Func<T> _getMax;
        
        public T Current
        {
            get=>_current;
            set
            {
                var old = _current;
                if (_valid == null) _current = DefaultValid(value, Min, Max);
                else _current = _valid.Invoke((Min, Max, old, value));
                InvokeEvent();
            }
        }
        [SerializeField] private T _current;
        
        public event Action Changed;
        #if HasAssets_UltEvents
        public UltEvent<T> NewCurrent;
        #endif

        public void SetMin(Func<T> f)
        {
            _getMin = f;
        }

        public void SetMax(Func<T> f)
        {
            _getMax = f;
        }

        public void SetValid(Func<(T min, T max, T oldV, T newV), T> f) => _valid = f;
            
        #if HasAssets_ODIN
        [Button] 
        #endif
        private void InvokeEvent()
        {
            Changed?.Invoke();
            #if HasAssets_UltEvents
            NewCurrent.Invoke(_current);
            #endif
        }

        #if HasAssets_ODIN
        [Button] 
        #endif
        public void Valid()
        {
            Current = Current;
        }

        protected abstract T DefaultValid(T current, T min, T max);
    }
}