using UnityEngine;

namespace Plugins.MaoUtility.Localization.Implementation.Res
{
    [System.Serializable]
    public class LocalSprite : MaoLocal<Sprite>
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _sprite;
        public override Sprite Get(string id) => _sprite;
        public override bool HasId(string id)
        {
            return _id == id;
        }
    }
}