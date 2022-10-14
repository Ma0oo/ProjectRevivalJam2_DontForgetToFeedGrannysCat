using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;

namespace Plugins.MaoUtility.SaveSystem.IO
{
    public abstract class Saver
    {
        public abstract T Load<T>(string path) where T : class;
        
        public abstract void Save<T>(T data, string path)  where T : class;

        public static JsonSerializerSettings GetSetting()
        {
            return new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Full,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }
    }
}