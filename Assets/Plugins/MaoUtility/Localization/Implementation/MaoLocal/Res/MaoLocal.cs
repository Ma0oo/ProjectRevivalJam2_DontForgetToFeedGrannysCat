using Plugins.MaoUtility.Localization.Core;
using UnityEngine;

namespace Plugins.MaoUtility.Localization.Implementation.Res
{
    [System.Serializable]
    public abstract class MaoLocal<T> : ILocalizationResources<T>
    {
        public abstract T Get(string id);

        public abstract bool HasId(string id);
        
        public virtual void OnLoad(){}
    }
}