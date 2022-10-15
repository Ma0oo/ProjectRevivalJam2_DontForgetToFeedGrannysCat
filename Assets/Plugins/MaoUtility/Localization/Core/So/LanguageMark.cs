using UnityEngine;

namespace Plugins.MaoUtility.Localization.Core
{
    [CreateAssetMenu(menuName = "MaoUtility/Localization/Lang", order = 51)]
    public class LanguageMark : ScriptableObject
    {
        public string ID;
        public string Name;
        public Sprite Sprite;

        public LanguageMarkComponentManager Components => _components;
        [SerializeField] private LanguageMarkComponentManager _components;
    }
}