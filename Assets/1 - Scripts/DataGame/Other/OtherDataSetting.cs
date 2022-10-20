using Newtonsoft.Json;
using Plugins.MaoUtility.IoUi.Btns;
using Plugins.MaoUtility.Localization.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DataGame.Other
{
    [System.Serializable]
    public class OtherDataSetting
    {
        public string SelectedLangId => _langId;
        [SerializeField, ReadOnly, JsonProperty] private string _langId;

        public void SaveSelectedID(LanguageMark languageMark) => _langId = languageMark.ID;
    }
}