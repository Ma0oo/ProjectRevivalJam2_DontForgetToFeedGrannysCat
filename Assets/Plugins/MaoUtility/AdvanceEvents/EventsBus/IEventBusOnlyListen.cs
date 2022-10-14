using System;

namespace Plugins.MaoUtility.AdvanceEvents.EventsBus
{
    public interface IEventBusOnlyListen
    {
        public void Sub<E>(Action<E> callback);

        public void Unsub<E>(Action<E> callback);

        public void InvokeLastCall<E>(Action<E> callback);

        public void SubAndInvoke<E>(Action<E> callback);
    }
}