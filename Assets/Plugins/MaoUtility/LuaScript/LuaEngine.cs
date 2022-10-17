using System;
using System.Dynamic;
//using MoonSharp.Interpreter;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Plugins.MaoUtility.LuaScript
{
    [System.Serializable]
    public class LuaEngine
    {
        //protected Script Lua;
        private AddLogicToLua[] _logics;

        public LuaEngine(string script, AddLogicToLua[] logics)
        {
            //Lua = new Script();
            _logics = logics;
            //logics.ForEach(x => Lua.Globals[x.GetNameObject()] = x.GetLogicObject());
            //Lua.DoString(script);
        }

        [Button]private void Log()
        {
            string dbgMes = "";
            _logics.ForEach(x => dbgMes += $"{x.GetNameObject()}\n{x.Log()}\n\n");
            Debug.Log(dbgMes);
        }
    }

    public class DebugLogic : AddLogicToLua
    {
        public override ExpandoObject GetLogicObject()
        {
            dynamic result = new ExpandoObject();
            result.Log = (Action<string>) (x => Debug.Log(x));
            result.LogE = (Action<string>) (x => Debug.LogError(x));
            result.LogW = (Action<string>) (x => Debug.LogWarning(x));
            return result;
        }

        public override string GetNameObject() => "Debug";
    }
}