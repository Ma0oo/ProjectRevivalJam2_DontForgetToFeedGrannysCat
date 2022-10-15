using System;
using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.Localization.Core;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Plugins.MaoUtility.Localization.Utility
{
    public abstract class RequestLocalization<T> : MonoBehaviour where T : class
    {
        public Localizator Localizator => _localizator??=DI.Instance.Get<Localizator>();
        private Localizator _localizator;

        public event Action LanguageChanged;

        protected virtual void Start() => Localizator.ChangeLanguage += OnChange;

        private void OnChange() => LanguageChanged?.Invoke();
        
        protected virtual void OnDestroy() => Localizator.ChangeLanguage -= OnChange;

        public T Get(string id) 
            => Localizator.Get<T>(id, $"Запрос от Name GM {name}, Name Parent {NameParent()}");

        public T GetWithoutLog(string id) 
            => Localizator.Get<T>(id, $"No log by MonoBeh");

        public T GetWithCustomLog(string id, string mes) 
            => Localizator.Get<T>(id, mes);

        private string NameParent() => transform.parent ? transform.parent.name : "None";
    }
}