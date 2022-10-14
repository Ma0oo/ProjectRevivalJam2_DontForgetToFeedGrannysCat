using System;
using System.Collections.Generic;
using Plugins.MaoUtility.AdvanceEvents.EventSlowpoke.Implementation;

namespace Plugins.MaoUtility.AdvanceEvents.EventsBus
{
    public class EventBusLimited<EOriginal> : IEventButLimitedOnlyListen<EOriginal>
    {
        private Dictionary<Type, object> _events = new Dictionary<Type, object>();
        
        public void Sub<E>(Action<E> callback) where E : EOriginal => GetOrCreateEvent<E>().Sub(callback);

        public void Unsub<E>(Action<E> callback) where E : EOriginal => GetOrCreateEvent<E>().Unsub(callback);

        public void Post<E>(E e) where E : EOriginal=> GetOrCreateEvent<E>().Post(e);

        public void InvokeLastCall<E>(Action<E> callback) where E : EOriginal=> GetOrCreateEvent<E>().InvokeLastCall(callback);

        public void SubAndInvoke<E>(Action<E> callback) where E : EOriginal=> GetOrCreateEvent<E>().SubAndInvoke(callback);

        private EventSlowpoke<E> GetOrCreateEvent<E>() where E : EOriginal
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