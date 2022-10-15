using System.Collections.Generic;
using UnityEngine;

namespace Plugins.MaoUtility.Localization.Core
{
    [CreateAssetMenu(menuName = "MaoUtility/Localization/Lang Cache", order = 51)]
    public class LanguageMarkCache : ScriptableObject
    {
        public IReadOnlyCollection<LanguageMark> Marks => _marks;
        [SerializeField] private LanguageMark[] _marks;
    }
}