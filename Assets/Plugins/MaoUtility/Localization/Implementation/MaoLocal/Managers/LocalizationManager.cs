using System;
using System.Collections.Generic;
using System.Linq;
using Plugins.MaoUtility.Localization.Implementation.Res;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Sirenix.Utilities;
using UnityEngine;

namespace Plugins.MaoUtility.Localization.Core
{
    public abstract class LocalizationManager<T> : SerializedScriptableObject, ILocalizationManager
    {
        public IReadOnlyCollection<MaoLocal<T>> Resources => _resources; 
        [NonSerialized, OdinSerialize] private MaoLocal<T>[] _resources;

        public LanguageMark Language => _language;
        [SerializeField] private LanguageMark _language;

        public T Get(string id)
        {
            var res = _resources.FirstOrDefault(x => x.HasId(id));
            if (res != null) return res.Get(id);
            else return default;
        }

        public void OnLoad() => Resources.ForEach(x => x.OnLoad());
    }

    public interface ILocalizationManager
    {
        LanguageMark Language { get; }
        void OnLoad();
    }
}