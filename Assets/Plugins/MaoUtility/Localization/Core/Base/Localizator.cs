using System;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace Plugins.MaoUtility.Localization.Core
{
    public abstract class Localizator : MonoBehaviour
    {
        public LanguageMark CurrentLanguage => _currentLanguage;
        [SerializeField, ReadOnly] private LanguageMark _currentLanguage;

        public event Action ChangeLanguage;

        public abstract T Get<T>(string id) where T : class;

        public abstract T Get<T>(string id, string mes) where T : class;

        [Button]public void ChangeLocal(LanguageMark mark)
        {
            if(CurrentLanguage==mark) return;
            _currentLanguage = mark;
            OnChangeLanguage();
            ChangeLanguage?.Invoke();
        }

        protected virtual void OnChangeLanguage() { }
    }
}