using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.IoUi.Core;
using UnityEngine;

namespace DataGame.Other
{
    [DiMark]
    public class IoLandIniter : IoIniter<IoLangHandler>
    {
        [DiInject] private DataProvider _dataProvider;
        
        public override void Register(IoLangHandler panel)
        {
            base.Register(panel);
            panel.Selected += x =>
            {
                _dataProvider.DataSettingCurrent.OtherDataSetting.SaveSelectedID(x);
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            };
        }
    }
}