using System;
using DataGame;
using Plugins.MaoUtility.DILocator.Atr;
using UnityEngine;

namespace DefaultNamespace
{
    [DiMark]
    public class ControllerAudioMixer : MonoBehaviour
    {
        [DiInject] private DataProvider _dataProvider;

        private void Start()
        {
            _dataProvider.DataSettingCurrent.Bus.Sub<DataSetting.DataUpdated>(OnUpdateValue);
            OnUpdateValue(new DataSetting.DataUpdated());
        }

        private void OnUpdateValue(DataSetting.DataUpdated @event)
        {
            var soundData = _dataProvider.DataSettingCurrent.SoundConfig;
            var cfg = ConfigGame.Instance;
            cfg.MixerMaster.SetValueToMixer(cfg.MixerAudio, soundData.Master);
            cfg.MixerEffect.SetValueToMixer(cfg.MixerAudio, soundData.Effect);
            cfg.MixerMusic.SetValueToMixer(cfg.MixerAudio, soundData.Music);
        }
    }
}