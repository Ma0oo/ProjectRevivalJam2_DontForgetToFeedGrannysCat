using System;
using System.Linq;
using Plugins.MaoUtility.Localization.Core;
using Plugins.MaoUtility.MonoBehsGameHelper;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Plugins.MaoUtility.Localization.Implementation.MaoLocal
{
    public class MaoLocalizator : Localizator
    {
        [ShowInInspector, ReadOnly] private LocalizationManagerClip[] _clips = new LocalizationManagerClip[0];
        [ShowInInspector, ReadOnly] private LocalizationManagerSprite[] _sprites= new LocalizationManagerSprite[0];
        [ShowInInspector, ReadOnly] private LocalizationManagerText[] _texts= new LocalizationManagerText[0];
        
        private WriteRequestLocalization _writeRequest;

        private void Start()
        {
            _writeRequest = new WriteRequestLocalization();
        }

        public override T Get<T>(string id) where T : class
        {
            _writeRequest.AddLog(id, "None");
            return DefaultGet<T>(id);
        }
        
        public override T Get<T>(string id, string mes) where T : class
        {
            _writeRequest.AddLog(id, mes);
            return DefaultGet<T>(id);
        }

        private T DefaultGet<T>(string id) where T : class
        {
            if(CurrentLanguage==null) ChangeLocal(LocalizationConfig.Instance.DefaultLang);
            
            if (typeof(T) == typeof(AudioClip))
                return Get<AudioClip>(_clips, x => x != null, id) as T;
            else if (typeof(T) == typeof(Sprite))
                return Get<Sprite>(_sprites, x => x != null, id) as T;
            else if (typeof(T) == typeof(string))
                return Get<string>(_texts, x => string.IsNullOrWhiteSpace((string) x), id, ()=> "NO "+id) as T;
            else
            {
                Debug.LogError($"{typeof(MaoLocalizator)} не может загрузить тип {typeof(T)}");
                return default;
            }
        }

        private T Get<T>(LocalizationManager<T>[] arrays, Func<T, bool> CheckNull, string id, Func<T> Default=null)
        {
            for (var i = 0; i < arrays.Length; i++)
            {
                var r =arrays[i].Get(id);
                if (!CheckNull(r)) return r;
            }

            if (Default == null) return default;
            else return Default();
        }

        protected override void OnChangeLanguage()
        {
            (new Object[0]).Concat(_clips).Concat(_sprites).Concat(_texts).ForEach(x => Resources.UnloadAsset(x));
            Load<LocalizationManagerClip>(x=>_clips=x);
            Load<LocalizationManagerSprite>(x=>_sprites=x);
            Load<LocalizationManagerText>(x=>_texts=x);
        }

        private void Load<T>(Action<T[]> set) where T : ScriptableObject, ILocalizationManager 
        {
            var loaded = Resources.LoadAll<T>("");
            var correctLoad = loaded.Where(x => x.Language == CurrentLanguage).ToArray();
            correctLoad.ForEach(x => x.OnLoad());
            set(correctLoad);
            loaded.Except(correctLoad).ForEach(x => Resources.UnloadAsset(x));
        }


        private void OnDestroy() => _writeRequest?.Save();
    }
}