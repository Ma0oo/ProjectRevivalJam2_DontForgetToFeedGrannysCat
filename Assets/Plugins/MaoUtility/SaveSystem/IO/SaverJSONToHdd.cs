using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Plugins.MaoUtility.SaveSystem.IO
{
    public class SaverJSONToHdd : Saver
    {
        public event Action LoseLoad;

        public override T Load<T>(string path)
        {
            if (!File.Exists(path))
            {
                LoseLoad?.Invoke();
                Debug.LogError($"по пути {path} нет нужного файла, возвращен пустой контейнер");
                return null;
            }

            var content = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(content)) content = "{}";
            var result = JsonConvert.DeserializeObject<T>(content, GetSetting());
            return result;
        }

        public override void Save<T>(T data, string path)
        {
            var content = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, content);
        }
    }
}