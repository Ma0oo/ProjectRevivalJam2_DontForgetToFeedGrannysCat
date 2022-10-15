using UnityEngine;

namespace Plugins.MaoUtility.Localization.Implementation.Res
{
    [System.Serializable]
    public class LocalText : MaoLocal<string>
    {
        [SerializeField] private string _id;
        [SerializeField] private string _text;
        public override string Get(string id) => _text;
        public override bool HasId(string id)
        {
            return _id == id;
        }
    }
}