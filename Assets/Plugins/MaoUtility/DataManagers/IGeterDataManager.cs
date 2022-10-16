using System;

namespace Plugins.MaoUtility.DataManagers
{
    public interface IGeterDataManager<T>
    {
        public T Get(Func<T, bool> predicate);

        public T[] GetAll(Func<T, bool> predicate);

        public T2 Get<T2>() where T2 : class, T;

        public T2[] GetAll<T2>() where T2 : T;
    }
}