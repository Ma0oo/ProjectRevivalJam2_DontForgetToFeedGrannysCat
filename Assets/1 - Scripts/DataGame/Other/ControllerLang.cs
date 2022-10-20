using System.Linq;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.Localization.Core;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;

namespace DataGame.Other
{
    [DiMark]
    public class ControllerLang : MonoBehaviour
    {
        [DiInject] private Localizator _localizator;
        [DiInject] private DataProvider _dataProvider;
        [DiInject] private LanguageMarkCache _languageMarkCache;

        private void Start()
        {
            CoroutineGame.Instance.WaitFrame(2, SetLang);
            _dataProvider.DataSettingCurrent.Bus.Sub((DataSetting.DataUpdated e)=>SetLang());
        }

        private void SetLang()
        {
            var id = _dataProvider.DataSettingCurrent.OtherDataSetting.SelectedLangId;
            var lang = _languageMarkCache.Marks.FirstOrDefault(x => x.ID == id);
            if (!lang) lang = LocalizationConfig.Instance.DefaultLang;
            _localizator.ChangeLocal(lang);
        }
    }
}