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
            
            //main
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
            
            
            //items
            panel.FirstItem.Init(()=>key.FirstItem, x=>
            {
                key.FirstItem = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.SecondItem.Init(()=>key.SecondItem, x=>
            {
                key.SecondItem = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.ThirdItem.Init(()=>key.ThirdItem, x=>
            {
                key.ThirdItem = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.FourtedItem.Init(()=>key.FourtedItem, x=>
            {
                key.FourtedItem = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.FiftenItem.Init(()=>key.FiftenItem, x=>
            {
                key.FiftenItem = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            
            //other
            panel.DropItem.Init(()=>key.DropItem, x=>
            {
                key.DropItem = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.CloseNote.Init(()=>key.CloseNote, x=>
            {
                key.CloseNote = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.MenuGame.Init(()=>key.MenuGame, x=>
            {
                key.MenuGame = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
        }
    }
}