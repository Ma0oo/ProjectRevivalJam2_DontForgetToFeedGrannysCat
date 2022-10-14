using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Plugins.MaoUtility.DataManagers
{
    public abstract class DataManagerMonoBeh<T> : MonoBehaviour where T : MonoBehaviour
    {
        public IReadOnlyCollection<T> ReadData => Datas;
        [SerializeField] protected List<T> Datas;
        
        public T Get(Func<T, bool> predicate) => Datas.FirstOrDefault(predicate);
        
        public T[] GetAll(Func<T, bool> predicate) => Datas.Where(predicate).ToArray();

        public T2 Get<T2>() where T2 : class, T => Get(x => x is T2) as T2;

        public T2[] GetAll<T2>() where T2 : T => GetAll(x => x is T2).Cast<T2>().ToArray();
    }
}