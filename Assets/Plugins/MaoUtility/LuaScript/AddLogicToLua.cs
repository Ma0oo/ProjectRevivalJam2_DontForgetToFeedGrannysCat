using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using Sirenix.Utilities;

namespace Plugins.MaoUtility.LuaScript
{
    public abstract class AddLogicToLua
    {
        public abstract ExpandoObject GetLogicObject();
        public abstract string GetNameObject();

        public string Log()
        {
            return GetLevelLog(0, GetLogicObject(), GetNameObject());
        }
        
        private string GetLevelLog(int level, object obj, string name)
        {
            string whiteSpace = new string(' ', level);
            if (obj is ExpandoObject)
            {
                string result = "";
                ((IDictionary<string, object>) obj).ForEach(x =>
                {
                    result += whiteSpace+ GetLevelLog(level + 1, x.Value, x.Key)+"\n";
                });
                return $"{whiteSpace}{name} - {obj.GetType()}:\n{result}";
            }
            else if(obj is object && !(obj is string))
            {
                BindingFlags flag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
                var t = obj.GetType();
                string result = whiteSpace+"Field\n";
                t.GetFields(flag).ForEach(x =>
                {
                    result += $"{whiteSpace}{GetLevelLog(level + 1, x.GetValue(obj), x.Name)}\n";
                });
                result+=whiteSpace+"Methods:\n";
                t.GetMethods(flag).ForEach(x =>
                {
                    result += $"{whiteSpace}No log method info";
                });
                return result;
            }
            else
            {
                return whiteSpace + $"{name} : {obj.GetType()}";
            }
        }
    }
}