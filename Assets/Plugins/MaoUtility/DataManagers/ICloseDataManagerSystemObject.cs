﻿using System;

namespace Plugins.MaoUtility.DataManagers
{
    public interface ICloseDataManagerSystemObject<T>
    {
        public event Action<T> Added;
        public event Action<T> Removed;
        
        public T Get(Func<T, bool> predicate);

        public T[] GetAll(Func<T, bool> predicate);

        public T2 Get<T2>() where T2 : class, T;

        public T2[] GetAll<T2>() where T2 : T;
    }
}