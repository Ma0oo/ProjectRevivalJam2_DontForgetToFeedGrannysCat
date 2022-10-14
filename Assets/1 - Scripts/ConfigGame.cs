using DataGame;
using Plugins.MaoUtility.MonoBehsGameHelper;
using UnityEngine;
using UnityEngine.Audio;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Configs/Game", order = 51)]
    public class ConfigGame : ConfigSo<ConfigGame>
    {
        public DataSetting DefaultSetting;
        public string GameScene;
        public string MenuScene;

        public AudioMixer MixerAudio;
        public GroupMixer MixerMaster;
        public GroupMixer MixerEffect;
        public GroupMixer MixerMusic;
        
        [System.Serializable]
        public class GroupMixer
        {
            public string Name;
            public float Min = -50;
            public float Max = 0;

            public void SetValueToMixer(AudioMixer mixer, float normal) => mixer.SetFloat(Name, Mathf.Lerp(Min, Max, normal));
        }
    }
}