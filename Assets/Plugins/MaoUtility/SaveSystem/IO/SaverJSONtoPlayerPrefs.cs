using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;

namespace Plugins.MaoUtility.SaveSystem.IO
{
    public class SaverJSONtoPlayerPrefs : Saver
    {
        public override T Load<T>(string path)
        {
            var result = PlayerPrefs.GetString(path, null);
            if (result == null) return null;
            return JsonConvert.DeserializeObject<T>(result, GetSetting());
        }

        public override void Save<T>(T data, string path)
        {
            var saveData = JsonConvert.SerializeObject(data, GetSetting());
            PlayerPrefs.SetString(path, saveData);
        }
    }
}