using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.IoUi.Core;

namespace DataGame.Keys
{
    [DiMark]
    public class IoKeyIniter : IoIniter<IoKeyHandler>
    {
        [DiInject] private DataProvider _dataProvider;

        public override void Register(IoKeyHandler panel)
        {
            base.Register(panel);
            var key = _dataProvider.DataSettingCurrent.Keys;
            panel.Back.Init(()=>key.Back, x=>
            {
                key.Back = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.Forward.Init(()=>key.Forward, x=>
            {
                key.Forward = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.Left.Init(()=>key.Left, x=>
            {
                key.Left = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.Right.Init(()=>key.Right, x=>
            {
                key.Right = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.Use.Init(()=>key.Use, x=>
            {
                key.Use = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.Crouch.Init(()=>key.Crouch, x=>
            {
                key.Crouch = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.Run.Init(()=>key.Run, x=>
            {
                key.Run = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.Jump.Init(()=>key.Jump, x=>
            {
                key.Jump = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
        }
    }
}