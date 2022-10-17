using Plugins.MaoUtility.DILocator.Core;
using UnityEngine;

namespace Plugins.MaoUtility.DILocator
{
    public class EaseGetFromDi : MonoBehaviour
    {
        public T Get<T>() => DI.Instance.Get<T>();

        public T Get<T>(object id) => DI.Instance.Get<T>(id);
    }

    public class LazyDi<T>
    {
        public T Value => _id == null ? DI.Instance.Get<T>() : DI.Instance.Get<T>(_id);

        private object _id;

        public LazyDi() => _id = null;
        
        public LazyDi(object id) => _id = id;
    }
}