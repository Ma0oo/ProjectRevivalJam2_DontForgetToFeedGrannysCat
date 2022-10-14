using System;
using UltEvents;
using UnityEngine;

namespace Plugins.MaoUtility.AdvanceEvents.EventSlowpoke.Implementation
{
    [System.Serializable]
    public class UltEventSlowpoke : IEventSlowpoke
    {
        [SerializeField] private UltEvent _e;
        
        public void Sub(Action callback) => _e.DynamicCalls += callback;

        public void Unsub(Action callback) => _e.DynamicCalls -= callback;

        public void InvokeLastCall(Action callback) => callback.Invoke();

        public void SubAndInvoke(Action callback)
        {
            Sub(callback);
            InvokeLastCall(callback);
        }

        public void Post() => _e.Invoke();
    }
    
    [System.Serializable]
    public class UltEventSlowpoke<T1> : IEventSlowpoke<T1>
    {
        [SerializeField] private UltEvent<T1> _e;
        
        private T1 _last1;
        
        public void Sub(Action<T1> callback) => _e.DynamicCalls += callback;

        public void Unsub(Action<T1> callback) => _e.DynamicCalls -= callback;

        public void InvokeLastCall(Action<T1> callback)
        {
            if(_last1!=null)
                callback.Invoke(_last1);
        }

        public void SubAndInvoke(Action<T1> callback)
        {
            Sub(callback);
            InvokeLastCall(callback);
        }

        public void Post(T1 obj1)
        {
            _last1 = obj1;
            _e.Invoke(obj1);
        }
    }
    
    [System.Serializable]
    public class UltEventSlowpoke<T1, T2> : IEventSlowpoke<T1, T2>
    {
        [SerializeField] private UltEvent<T1, T2> _e;
        
        private T1 _last1;
        private T2 _last2;

        public void Sub(Action<T1, T2> callback) => _e.DynamicCalls += callback;

        public void Unsub(Action<T1, T2> callback) => _e.DynamicCalls -= callback;

        public void InvokeLastCall(Action<T1, T2> callback)
        {
            if(_last1!=null && _last2!=null)
                callback.Invoke(_last1, _last2);
        }

        public void SubAndInvoke(Action<T1, T2> callback)
        {
            Sub(callback);
            InvokeLastCall(callback);
        }

        public void Post(T1 obj1, T2 obj2)
        {
            _last1 = obj1;
            _last2 = obj2;
            _e.Invoke(obj1, obj2);
        }
    }
    
    [System.Serializable]
    public class UltEventSlowpoke<T1, T2, T3> : IEventSlowpoke<T1, T2, T3>
    {
        [SerializeField] private UltEvent<T1, T2, T3> _e;
        
        private T1 _last1;
        private T2 _last2;
        private T3 _last3;

        public void Sub(Action<T1, T2, T3> callback) => _e.DynamicCalls += callback;

        public void Unsub(Action<T1, T2, T3> callback) => _e.DynamicCalls -= callback;

        public void InvokeLastCall(Action<T1, T2, T3> callback)
        {
            if(_last1!=null && _last2!=null && _last3!=null)
                callback.Invoke(_last1, _last2, _last3);
        }

        public void SubAndInvoke(Action<T1, T2, T3> callback)
        {
            Sub(callback);
            InvokeLastCall(callback);
        }

        public void Post(T1 obj1, T2 obj2, T3 obj3)
        {
            _last1 = obj1;
            _last2 = obj2;
            _last3 = obj3;
            _e.Invoke(obj1, obj2, obj3);
        }
    }
    
    [System.Serializable]
    public class UltEventSlowpoke<T1, T2, T3, T4> : IEventSlowpoke<T1, T2, T3, T4>
    {
        [SerializeField] private UltEvent<T1, T2, T3, T4> _e;
        
        private T1 _last1;
        private T2 _last2;
        private T3 _last3;
        private T4 _last4;

        public void Sub(Action<T1, T2, T3, T4> callback) => _e.DynamicCalls += callback;

        public void Unsub(Action<T1, T2, T3, T4> callback) => _e.DynamicCalls -= callback;

        public void InvokeLastCall(Action<T1, T2, T3, T4> callback)
        {
            if(_last1!=null && _last2!=null && _last3!=null && _last4!=null)
                callback.Invoke(_last1, _last2, _last3, _last4);    
        }

        public void SubAndInvoke(Action<T1, T2, T3, T4> callback)
        {
            Sub(callback);
            InvokeLastCall(callback);
        }

        public void Post(T1 obj1, T2 obj2, T3 obj3, T4 obj4)
        {
            _last1 = obj1;
            _last2 = obj2;
            _last3 = obj3;
            _last4 = obj4;
            _e.Invoke(obj1, obj2, obj3, obj4);
        }
    }
}