using System.Collections.Generic;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Plugins.MaoUtility.Localization.Implementation.Res
{
    [System.Serializable]
    public class LocalTextJson : MaoLocal<string>
    {
        [SerializeField] private TextAsset _file;

        public Dictionary<string, string> Texts
        {
            get
            {
                if (_texts != null) return _texts;
                OnLoad();
                return _texts;
            }
        }

        private Dictionary<string, string> _texts;

        public override string Get(string id)
        {
            Texts.TryGetValue(id, out var r);
            return r;
        }

        public override bool HasId(string id) => Texts.ContainsKey(id);

        public override void OnLoad() 
            => _texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(_file.text, Setting());

        [Button]private void ExampleJSON()
        {
            var exp = new Dictionary<string, string>();
            exp.Add("Key1", "V1");
            exp.Add("Key2", "V2");
            Debug.Log(JsonConvert.SerializeObject(exp, Setting()));
        }
        
        private JsonSerializerSettings Setting()
        {
            return new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.None,
                Formatting = Formatting.Indented
            };
        }
    }
}