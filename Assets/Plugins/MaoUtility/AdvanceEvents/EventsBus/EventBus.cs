using System;
using System.Collections.Generic;
using Plugins.MaoUtility.AdvanceEvents.EventSlowpoke.Implementation;

namespace Plugins.MaoUtility.AdvanceEvents.EventsBus
{
    public class EventBus : IEventBusOnlyListen
    {
        private Dictionary<Type, object> _events = new Dictionary<Type, object>();
        
        public void Sub<E>(Action<E> callback) => GetOrCreateEvent<E>().Sub(callback);

        public void Unsub<E>(Action<E> callback) => GetOrCreateEvent<E>().Unsub(callback);

        public void Post<E>(E e) => GetOrCreateEvent<E>().Post(e);

        public void InvokeLastCall<E>(Action<E> callback) => GetOrCreateEvent<E>().InvokeLastCall(callback);

        public void SubAndInvoke<E>(Action<E> callback) => GetOrCreateEvent<E>().SubAndInvoke(callback);

        private EventSlowpoke<E> GetOrCreateEvent<E>()
        {
            if (_events.ContainsKey(typeof(E))) return _events[typeof(E)] as EventSlowpoke<E>;
            else
            {
                EventSlowpoke<E> e = new EventSlowpoke<E>();
                _events.Add(typeof(E), e);
                return e;
            }
        } 
    }
}