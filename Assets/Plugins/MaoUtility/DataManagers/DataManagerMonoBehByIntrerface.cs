using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Plugins.MaoUtility.DataManagers
{
    public class DataManagerMonoBehByIntrerface<T> : SerializedMonoBehaviour, IGeterDataManager<T> where T : IMonoBehaviour
    {
        public IReadOnlyCollection<T> ReadMono => Monos;
        [NonReorderable, OdinSerialize] protected List<T> Monos;
        
        public T Get(Func<T, bool> predicate) => Monos.FirstOrDefault(predicate);

        public T[] GetAll(Func<T, bool> predicate) => Monos.Where(predicate).ToArray();

        //public IMonoBehaviour Get(Func<IMonoBehaviour, bool> predicate) 
          //  => ((IGeterDataManager<T>) this).Get(x => predicate(x));

        //public IMonoBehaviour[] GetAll(Func<IMonoBehaviour, bool> predicate) 
          //  => ((IGeterDataManager<T>) this).GetAll(x => predicate(x)).Cast<IMonoBehaviour>().ToArray();

        public T2 Get<T2>() where T2 : class, T => ((IGeterDataManager<T>)this).Get(x => x is T2) as T2;

        public T2[] GetAll<T2>() where T2 : T => ((IGeterDataManager<T>)this).GetAll(x => x is T2).Cast<T2>().ToArray();
    }
}