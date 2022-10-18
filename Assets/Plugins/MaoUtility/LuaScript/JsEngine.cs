using System;
using Jint;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Plugins.MaoUtility.LuaScript
{
    [System.Serializable]
    public abstract class JsEngine
    {
        [ShowInInspector]protected Engine JS;
        private AddLogicToLua[] _logics;

        public JsEngine(string script, AddLogicToLua[] logics)
        {
            JS = new Engine();
            _logics = logics;
            logics.ForEach(x => JS.SetValue(x.GetNameObject(), x.GetLogicObject()));
            JS.Execute(script);
        }

        [Button]private void Log()
        {
            string dbgMes = "";
            _logics.ForEach(x => dbgMes += $"{x.GetNameObject()}\n{x.Log()}\n\n");
            Debug.Log(dbgMes);
        }

        protected void CallMethod(string name, params object[] objs) => JS.Invoke(name, objs);

        protected void CallMethod(string name) => JS.Invoke(name);
    }
}