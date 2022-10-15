using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace Plugins.MaoUtility.DataManagers
{
    [System.Serializable]
    public abstract class DataManagerSystemObject<T> : ICloseDataManager<T> where T : class, ICloneable
    {
        public IReadOnlyCollection<T> Data => Datas;
        [SerializeReference, JsonProperty] protected List<T> Datas=new List<T>();

        public event Action<T> Added;
        public event Action<T> Removed;

        public void Add(T value)
        {
            if (!Datas.Contains(value))
            {
                Datas.Add(value);
                Added?.Invoke(value);
            }
        }

        public void Remove(T value)
        {
            if(Datas.Remove(value))
                Removed?.Invoke(value);
        }

        public T Get(Func<T, bool> predicate) => Datas.FirstOrDefault(predicate);
        
        public T[] GetAll(Func<T, bool> predicate) => Datas.Where(predicate).ToArray();

        public T2 Get<T2>() where T2 : class, T => Get(x => x is T2) as T2;

        public T2[] GetAll<T2>() where T2 : T => GetAll(x => x is T2).Cast<T2>().ToArray();

        public DataManagerSystemObject<T> Clone()
        {
            var r = (DataManagerSystemObject<T>) Activator.CreateInstance(GetType()); 
            Datas.ForEach(x=>r.Datas.Add(x.Clone() as T));
            return r;
        }
    }
}