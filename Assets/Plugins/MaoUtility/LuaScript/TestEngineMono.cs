using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Plugins.MaoUtility.LuaScript
{
    [System.Serializable]
    public class TestEngineMono : MonoBehaviour
    {
        [SerializeField] private JsScriptContainer jsScriptContainer;
        [ShowInInspector]private TestEngine _luaEngine;

        private void Start()
        {
            _luaEngine = new TestEngine(jsScriptContainer.Script, new AddLogicToLua[]{new DebugLogic()});
            _luaEngine.Start();
        }

        private void OnValidate() => jsScriptContainer.OnValidate();
    }
}