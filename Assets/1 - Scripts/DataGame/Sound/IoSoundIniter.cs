using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.IoUi.Core;
using UnityEngine;

namespace DataGame.Sound
{
    [DiMark]
    public class IoSoundIniter : IoIniter<IoSoundHandler>
    {
        [DiInject] private DataProvider _dataProvider;
        
        public override void Register(IoSoundHandler panel)
        {
            base.Register(panel);
            var sound = _dataProvider.DataSettingCurrent.SoundConfig;
            panel.Effect.Init(()=>sound.Effect, x =>
            {
                sound.Effect = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.Master.Init(()=>sound.Master, x =>
            {
                sound.Master = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
            panel.Music.Init(()=>sound.Music, x =>
            {
                sound.Music = x;
                _dataProvider.DataSettingCurrent.Bus.Post(new DataSetting.DataUpdated());
            });
        }
    }
}