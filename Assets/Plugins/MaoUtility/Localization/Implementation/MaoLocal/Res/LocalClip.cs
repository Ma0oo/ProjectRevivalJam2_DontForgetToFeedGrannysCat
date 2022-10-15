using UnityEngine;

namespace Plugins.MaoUtility.Localization.Implementation.Res
{
    [System.Serializable]
    public class LocalClip : MaoLocal<AudioClip>
    {
        [SerializeField] private string _id;
        [SerializeField] private AudioClip _clip;
        public override AudioClip Get(string id) => _clip;

        public override bool HasId(string id)
        {
            return _id == id;
        }
    }
}