using System;

namespace Plugins.MaoUtility.AdvanceEvents.EventsBus
{
    public interface IEventButLimitedOnlyListen<EOriginal>
    {
        public void Sub<E>(Action<E> callback) where E : EOriginal;

        public void Unsub<E>(Action<E> callback) where E : EOriginal;

        public void InvokeLastCall<E>(Action<E> callback) where E : EOriginal;

        public void SubAndInvoke<E>(Action<E> callback) where E : EOriginal;
    }
}