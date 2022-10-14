using System;
using UnityEngine;

namespace Plugins.MaoUtility.AdvanceEvents.EventSlowpoke.Implementation
{
    public class EventSlowpoke : IEventSlowpoke
    {
        private event Action _event;

        public void Sub(Action callback) => _event += callback;

        public void SubAndInvoke(Action callback)
        {
            Sub(callback);
            InvokeLastCall(callback);
        }
        
        public void Unsub(Action callback) => _event -= callback;

        public void Post()
        {
            _event?.Invoke();
        }

        public void InvokeLastCall(Action callback)
        {
            callback.Invoke();
        }
    }
    
    public class EventSlowpoke<T> : IEventSlowpoke<T>
    {
        private T _lastCall;
        private event Action<T> _event;

        public void Sub(Action<T> callback) => _event += callback;

        public void SubAndInvoke(Action<T> callback)
        {
            Sub(callback);
            InvokeLastCall(callback);
        }
        
        public void Unsub(Action<T> callback) => _event -= callback;

        public void Post(T t)
        {
            _lastCall = t;
            _event?.Invoke(_lastCall);
        }

        public void InvokeLastCall(Action<T> callback)
        {
            if(_lastCall!=null)
                callback.Invoke(_lastCall);
        }
    }
    
    public class EventSlowpoke<T1, T2> : IEventSlowpoke<T1, T2>
    {
        private T1 _last1;
        private T2 _last2;
        private event Action<T1, T2> _event;

        public void Sub(Action<T1, T2> callback) => _event += callback;

        public void SubAndInvoke(Action<T1, T2> callback)
        {
            Sub(callback);
            InvokeLastCall(callback);
        }
        
        public void Unsub(Action<T1, T2> callback) => _event -= callback;

        public void Post(T1 t1, T2 t2)
        {
            _last1 = t1;
            _last2 = t2;
            _event?.Invoke(_last1, _last2);
        }

        public void InvokeLastCall(Action<T1, T2> callback)
        {
            if(_last1!=null)
                callback.Invoke(_last1, _last2);
        }
    }
    
    public class EventSlowpoke<T1, T2, T3> : IEventSlowpoke<T1, T2, T3>
    {
        private T1 _last1;
        private T2 _last2;
        private T3 _last3;
        private event Action<T1, T2, T3> _event;

        public void Sub(Action<T1, T2, T3> callback) => _event += callback;

        public void SubAndInvoke(Action<T1, T2, T3> callback)
        {
            Sub(callback);
            InvokeLastCall(callback);
        }
        
        public void Unsub(Action<T1, T2, T3> callback) => _event -= callback;

        public void Post(T1 t1, T2 t2, T3 t3)
        {
            _last1 = t1;
            _last2 = t2;
            _last3 = t3;
            _event?.Invoke(_last1, _last2, _last3);
        }

        public void InvokeLastCall(Action<T1, T2, T3> callback)
        {
            if(_last1!=null)
                callback.Invoke(_last1, _last2, _last3);
        }
    }
    
    public class EventSlowpoke<T1, T2, T3, T4> : IEventSlowpoke<T1, T2, T3, T4>
    {
        private T1 _last1;
        private T2 _last2;
        private T3 _last3;
        private T4 _last4;
        private event Action<T1, T2, T3, T4> _event;

        public void Sub(Action<T1, T2, T3, T4> callback) => _event += callback;

        public void SubAndInvoke(Action<T1, T2, T3, T4> callback)
        {
            Sub(callback);
            InvokeLastCall(callback);
        }
        
        public void Unsub(Action<T1, T2, T3, T4> callback) => _event -= callback;

        public void Post(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            _last1 = t1;
            _last2 = t2;
            _last3 = t3;
            _last4 = t4;
            _event?.Invoke(_last1, _last2, _last3, _last4);
        }

        public void InvokeLastCall(Action<T1, T2, T3, T4> callback)
        {
            if(_last1!=null)
                callback.Invoke(_last1, _last2, _last3, _last4);
        }
    }
}
