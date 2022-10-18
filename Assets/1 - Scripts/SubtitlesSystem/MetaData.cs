using UnityEngine;

namespace DefaultNamespace.SubtitlesSystem
{
    [CreateAssetMenu(menuName = "Game/Subtitles/Meta", order = 51)]
    public class MetaData : ScriptableObject
    {
        public string KeyOwner;
        public Color Color;
    }
}