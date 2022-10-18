using System.IO;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Plugins.MaoUtility.LuaScript
{
    [System.Serializable]
    public class JsScriptContainer
    {
        [SerializeField] private Object _unityObj;

        public string Script => _script;
        [SerializeField, Multiline(5), ReadOnly] private string _script;

        [Button]public void OnValidate()
        {
            if (_unityObj)
            {
#if UNITY_EDITOR
                _script= File.ReadAllText(UnityEditor.AssetDatabase.GetAssetPath(_unityObj));
#endif
            }
            else
            {
                _script = "";
            }
        }
    }
}