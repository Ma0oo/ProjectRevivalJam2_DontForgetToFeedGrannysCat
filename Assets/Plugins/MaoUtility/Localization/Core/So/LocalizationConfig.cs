using Plugins.MaoUtility.MonoBehsGameHelper;
using UnityEngine;

namespace Plugins.MaoUtility.Localization.Core
{
    [CreateAssetMenu(menuName = "MaoUtility/Localization/Config", order = 51)]
    public class LocalizationConfig : ConfigSo<LocalizationConfig>
    {
        public bool WriteRequest => _writeRequest && Application.isEditor;
        [SerializeField] private bool _writeRequest;
        public string PathToWrite;
        public bool PathByAssets;
        
        public LanguageMark DefaultLang;
        [SerializeReference] public SelectorLocalization SelectedLocalizator;
    }
}