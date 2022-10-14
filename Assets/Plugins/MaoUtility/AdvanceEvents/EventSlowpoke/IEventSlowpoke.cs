using System;

namespace Plugins.MaoUtility.AdvanceEvents.EventSlowpoke
{
    public interface IEventSlowpoke
    {
        void Sub(Action callback);
        void Unsub(Action callback);
        void InvokeLastCall(Action callback);
        void SubAndInvoke(Action callback);
        void Post();
    }
    
    public interface IEventSlowpoke<E>
    {
        void Sub(Action<E> callback);
        void Unsub(Action<E> callback);
        void InvokeLastCall(Action<E> callback);
        void SubAndInvoke(Action<E> callback);
        void Post(E value);
    }
    
    public interface IEventSlowpoke<E1, E2>
    {
        void Sub(Action<E1, E2> callback);
        void Unsub(Action<E1, E2> callback);
        void InvokeLastCall(Action<E1, E2> callback);
        void SubAndInvoke(Action<E1, E2> callback);
        void Post(E1 obj1, E2 obj2);
    }
    
    public interface IEventSlowpoke<E1, E2, E3>
    {
        void Sub(Action<E1, E2, E3> callback);
        void Unsub(Action<E1, E2, E3> callback);
        void InvokeLastCall(Action<E1, E2, E3> callback);
        void SubAndInvoke(Action<E1, E2, E3> callback);
        void Post(E1 obj1, E2 obj2, E3 obj3);
    }
    
    public interface IEventSlowpoke<E1, E2, E3, E4>
    {
        void Sub(Action<E1, E2, E3, E4> callback);
        void Unsub(Action<E1, E2, E3, E4> callback);
        void InvokeLastCall(Action<E1, E2, E3, E4> callback);
        void SubAndInvoke(Action<E1, E2, E3, E4> callback);
        void Post(E1 obj1, E2 obj2, E3 obj3, E4 obj4);
    }
}