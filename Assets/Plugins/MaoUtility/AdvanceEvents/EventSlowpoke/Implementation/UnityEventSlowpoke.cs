using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Plugins.MaoUtility.AdvanceEvents.EventSlowpoke.Implementation
{
    [System.Serializable]
    public class UnityEventSlowpoke : UnityEvent, IEventSlowpoke
    {
        private Dictionary<Action, UnityAction> _actions = new Dictionary<Action, UnityAction>();
        
        public void Sub(Action callback) => AddListener(GetActions(callback));

        public void Unsub(Action callback)
        {
            RemoveListener(GetActions(callback));
            _actions.Remove(callback);
        }

        public void InvokeLastCall(Action callback) => GetActions(callback).Invoke();

        public void SubAndInvoke(Action callback)
        {
            Sub(callback);
            InvokeLastCall(callback);
        }

        public void Post() => Invoke();

        private UnityAction GetActions(Action callback)
        {
            _actions.TryGetValue(callback, out var r);
            if (r == null)
            {
                var r2 = new UnityAction(callback);
                _actions.Add(callback, r2);
                return r2;
            }
            return r;
        }
    }
    
    [System.Serializable]
    public class UnityEventSlowpoke<T1> : UnityEvent<T1>, IEventSlowpoke<T1>
    {
        private Dictionary<Action<T1>, UnityAction<T1>> _actions = new Dictionary<Action<T1>, UnityAction<T1>>();

        private T1 _last1;
        
        public void Sub(Action<T1> callback) => AddListener(GetActions(callback));

        public void Unsub(Action<T1> callback)
        {
            RemoveListener(GetActions(callback));
            _actions.Remove(callback);
        }

        public void InvokeLastCall(Action<T1> callback)
        {
            if(_last1!=null)
                GetActions(callback).Invoke(_last1);
        }

        public void SubAndInvoke(Action<T1> callback)
        {
            Sub(callback);
            InvokeLastCall(callback);
        }

        public void Post(T1 obj1)
        {
            _last1 = obj1;
            Invoke(obj1);
        }

        private UnityAction<T1> GetActions(Action<T1> callback)
        {
            _actions.TryGetValue(callback, out var r);
            if (r == null)
            {
                var r2 = new UnityAction<T1>(callback);
                _actions.Add(callback, r2);
                return r2;
            }
            return r;
        }
    }
    
    [System.Serializable]
    public class UnityEventSlowpoke<T1, T2> : UnityEvent<T1, T2>, IEventSlowpoke<T1, T2>
    {
        private Dictionary<Action<T1, T2>, UnityAction<T1, T2>> _actions = new Dictionary<Action<T1, T2>, UnityAction<T1, T2>>();

        private T1 _last1;
        private T2 _last2;
        
        public void Sub(Action<T1, T2> callback) => AddListener(GetActions(callback));

        public void Unsub(Action<T1, T2> callback)
        {
            RemoveListener(GetActions(callback));
            _actions.Remove(callback);
        }

        public void InvokeLastCall(Action<T1, T2> callback)
        {
            if(_last1!=null && _last2!=null)
                GetActions(callback).Invoke(_last1, _last2);
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
            Invoke(obj1, obj2);
        }

        private UnityAction<T1, T2> GetActions(Action<T1, T2> callback)
        {
            _actions.TryGetValue(callback, out var r);
            if (r == null)
            {
                var r2 = new UnityAction<T1, T2>(callback);
                _actions.Add(callback, r2);
                return r2;
            }
            return r;
        }
    }
    
    [System.Serializable]
    public class UnityEventSlowpoke<T1, T2, T3> : UnityEvent<T1, T2, T3>, IEventSlowpoke<T1, T2, T3>
    {
        private Dictionary<Action<T1, T2, T3>, UnityAction<T1, T2, T3>> _actions = new Dictionary<Action<T1, T2, T3>, UnityAction<T1, T2, T3>>();

        private T1 _last1;
        private T2 _last2;
        private T3 _last3;
        
        public void Sub(Action<T1, T2, T3> callback) => AddListener(GetActions(callback));

        public void Unsub(Action<T1, T2, T3> callback)
        {
            RemoveListener(GetActions(callback));
            _actions.Remove(callback);
        }

        public void InvokeLastCall(Action<T1, T2, T3> callback)
        {
            if(_last1!=null && _last2!=null & _last3!=null)
                GetActions(callback).Invoke(_last1, _last2, _last3);
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
            Invoke(obj1, obj2, obj3);
        }

        private UnityAction<T1, T2, T3> GetActions(Action<T1, T2, T3> callback)
        {
            _actions.TryGetValue(callback, out var r);
            if (r == null)
            {
                var r2 = new UnityAction<T1, T2, T3>(callback);
                _actions.Add(callback, r2);
                return r2;
            }
            return r;
        }
    }
    
    [System.Serializable]
    public class UnityEventSlowpoke<T1, T2, T3, T4> : UnityEvent<T1, T2, T3, T4>, IEventSlowpoke<T1, T2, T3, T4>
    {
        private Dictionary<Action<T1, T2, T3, T4>, UnityAction<T1, T2, T3, T4>> _actions = new Dictionary<Action<T1, T2, T3, T4>, UnityAction<T1, T2, T3, T4>>();

        private T1 _last1;
        private T2 _last2;
        private T3 _last3;
        private T4 _last4;
        
        public void Sub(Action<T1, T2, T3, T4> callback) => AddListener(GetActions(callback));

        public void Unsub(Action<T1, T2, T3, T4> callback)
        {
            RemoveListener(GetActions(callback));
            _actions.Remove(callback);
        }

        public void InvokeLastCall(Action<T1, T2, T3, T4> callback)
        {
            if(_last1!=null && _last2!=null && _last3!=null && _last4!=null)
                GetActions(callback).Invoke(_last1, _last2, _last3, _last4);
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
            Invoke(obj1, obj2, obj3, obj4);
        }

        private UnityAction<T1, T2, T3, T4> GetActions(Action<T1, T2, T3, T4> callback)
        {
            _actions.TryGetValue(callback, out var r);
            if (r == null)
            {
                var r2 = new UnityAction<T1, T2, T3, T4>(callback);
                _actions.Add(callback, r2);
                return r2;
            }
            return r;
        }
    }
}