using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;

namespace Plugins.MaoUtility.Localization.Core
{
    public class RegisterLocalization : RegisterDI
    {
        [SerializeField] private LanguageMarkCache _languageMarks;
        
        protected override void Register(DI di)
        {
            _languageMarks.With(x => di.Set(_languageMarks), !di.Has<LanguageMarkCache>());
            if(!di.Has<Localizator>()) di.Set<Localizator>(CreateLocalizator());
        }

        protected override void Unregister(DI di)
        {
            
        }

        private Localizator CreateLocalizator()
        {
            var gm = new GameObject(nameof(Localizator));
            DontDestroyOnLoad(gm);
            return gm.AddComponent(LocalizationConfig.Instance.SelectedLocalizator.GetTypeLocalizator()) as Localizator;
        }
    }
}