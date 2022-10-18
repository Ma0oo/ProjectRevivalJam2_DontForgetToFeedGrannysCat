using System;
using System.Dynamic;
using UnityEngine;

namespace Plugins.MaoUtility.LuaScript
{
    public class DebugLogic : AddLogicToLua
    {
        public override ExpandoObject GetLogicObject()
        {
            dynamic result = new ExpandoObject();
            
            result.Log = new Action<string>(x=>Debug.Log(x));
            result.LogE = new Action<string>(x=>Debug.LogError(x));
            result.LogW = new Action<string>(x=>Debug.LogWarning(x));
            return result;
        }

        public override string GetNameObject() => "Debug";
    }
}