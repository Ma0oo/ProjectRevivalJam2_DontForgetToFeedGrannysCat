using System;
using UltEvents;
using UnityEngine;
using UnityEngine.Events;

namespace Plugins.MaoUtility.AdvanceEvents
{
    [System.Serializable]
    public class GroupEvent
    {
        private event Action _e;
        [SerializeField] private UnityEvent _eUnity;
        [SerializeField] private UltEvent _eUlt;

        public void Invoke()
        {
            _e.Invoke();
            _eUlt.Invoke();
            _eUnity.Invoke();
        }

        public void Sub(Action callback) => _e += callback;
        
        public void Unsub(Action callback) => _e -= callback;
    }
    
    [System.Serializable]
    public class GroupEvent<T1>
    {
        private event Action<T1> _e;
        [SerializeField] private UnityEvent<T1> _eUnity;
        [SerializeField] private UltEvent<T1> _eUlt;

        public void Invoke(T1 o1)
        {
            _e.Invoke(o1);
            _eUlt.Invoke(o1);
            _eUnity.Invoke(o1);
        }

        public void Sub(Action<T1> callback) => _e += callback;
        
        public void Unsub(Action<T1> callback) => _e -= callback;
    }
    
    [System.Serializable]
    public class GroupEvent<T1, T2>
    {
        private event Action<T1, T2> _e;
        [SerializeField] private UnityEvent<T1, T2> _eUnity;
        [SerializeField] private UltEvent<T1, T2> _eUlt;

        public void Invoke(T1 o1, T2 o2)
        {
            _e.Invoke(o1, o2);
            _eUlt.Invoke(o1, o2);
            _eUnity.Invoke(o1, o2);
        }

        public void Sub(Action<T1, T2> callback) => _e += callback;
        
        public void Unsub(Action<T1, T2> callback) => _e -= callback;
    }
    
    [System.Serializable]
    public class GroupEvent<T1, T2, T3>
    {
        private event Action<T1, T2, T3> _e;
        [SerializeField] private UnityEvent<T1, T2, T3> _eUnity;
        [SerializeField] private UltEvent<T1, T2, T3> _eUlt;

        public void Invoke(T1 o1, T2 o2, T3 o3)
        {
            _e.Invoke(o1, o2, o3);
            _eUlt.Invoke(o1, o2, o3);
            _eUnity.Invoke(o1, o2, o3);
        }

        public void Sub(Action<T1, T2, T3> callback) => _e += callback;
        
        public void Unsub(Action<T1, T2, T3> callback) => _e -= callback;
    }
    
    [System.Serializable]
    public class GroupEvent<T1, T2, T3, T4>
    {
        private event Action<T1, T2, T3, T4> _e;
        [SerializeField] private UnityEvent<T1, T2, T3, T4> _eUnity;
        [SerializeField] private UltEvent<T1, T2, T3, T4> _eUlt;

        public void Invoke(T1 o1, T2 o2, T3 o3, T4 o4)
        {
            _e.Invoke(o1, o2, o3, o4);
            _eUlt.Invoke(o1, o2, o3, o4);
            _eUnity.Invoke(o1, o2, o3, o4);
        }

        public void Sub(Action<T1, T2, T3, T4> callback) => _e += callback;
        
        public void Unsub(Action<T1, T2, T3, T4> callback) => _e -= callback;
    }
}