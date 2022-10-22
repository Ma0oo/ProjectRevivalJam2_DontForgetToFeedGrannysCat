namespace Plugins.MaoUtility.LuaScript
{
    [System.Serializable]
    public class TestEngine : JsEngine
    {
        public TestEngine(string script, AddLogicToLua[] logics) : base(script, logics)
        {
            
        }

        public void Start() => CallMethod("OnStart");
    }
}