using System;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Plugins.MaoUtility.MonoBehsGameHelper
{
    public abstract class ConfigSo<T> : ScriptableObject where T : ScriptableObject, new()
    {
        private static T _instance;
        
       [ShowInInspector, ReadOnly] private T _selectInstance => _instance;
        
        private static T[] Load() => Resources.LoadAll<T>("");

        public static T Instance
        {
            get
            {
                if(_instance) return _instance;
                var configs = Resources.FindObjectsOfTypeAll<T>();
                if (configs.Length == 0)
                {
                    configs = Load();
                }
                if (configs.Length == 0)
                {
                    Debug.LogError($"В проекте нет конфига типа {typeof(T).Name}. Создайте его. Сейчас будет дефолтная реализация");
                    return null;
                }
                #if UNITY_EDITOR    
                configs = configs.Where(x => !string.IsNullOrWhiteSpace(UnityEditor.AssetDatabase.GetAssetPath(x))).ToArray();
                #endif    
                if (configs.Length > 1)
                {
                    #if UNITY_EDITOR
                    var info = "";
                    configs.ForEach(x =>
                    {
                        var path = UnityEditor.AssetDatabase.GetAssetPath(x);
                        info += $"{x.name} | {path} \n";
                    });
                    Debug.LogWarning($"В проекте конфигов типа {typeof(T).Name} больше чем 1. Будет взят 1-ый. Cписок всех конфигов \n" + info);
                    #endif
                }
                _instance= configs[0];
                return _instance;
            }
        }
    }
}