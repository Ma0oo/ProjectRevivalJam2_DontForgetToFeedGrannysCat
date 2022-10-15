using System;
using System.Net.Mail;

namespace Plugins.MaoUtility.SM
{
    public abstract class SmBase<T> : IClosedSM<T>
    {
        public abstract T Current { get; }
        
        public abstract event Action<T> ExitFrom;
        public abstract event Action<T> EnterTo;
        public abstract event Action<T, T> FailedChange;
        
        public abstract void ChangeTo(T newState);

        public abstract bool ValidChange(T oldState, T newState);
    }
    
    public interface IClosedSM<T>
    {
        T Current { get; }
        
        event Action<T> ExitFrom;
        event Action<T> EnterTo;
        event Action<T, T> FailedChange;
    }
}