using System;

namespace Plugins.MaoUtility.DataManagers
{
    public interface ICloseDataManager<T> : IGeterDataManager<T>
    {
        public event Action<T> Added;
        public event Action<T> Removed;
    }
}