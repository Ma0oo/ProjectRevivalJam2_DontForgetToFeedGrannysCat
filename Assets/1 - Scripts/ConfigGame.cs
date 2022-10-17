using System.Runtime.CompilerServices;
using DataGame;
using DataGame.Save;
using Plugins.MaoUtility.MonoBehsGameHelper;
using UnityEngine;
using UnityEngine.Audio;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Configs/Game", order = 51)]
    public class ConfigGame : ConfigSo<ConfigGame>
    {
        [Header("Datas")]
        public DataSetting DefaultSetting;
        public SaveData DefaultProgress;
        
        [Header("Scenes")]
        public string GameScene;
        public string MenuScene;

        [Header("Sounds")]
        public AudioMixer MixerAudio;
        public GroupMixer MixerMaster;
        public GroupMixer MixerEffect;
        public GroupMixer MixerMusic;
        
        public Mesh HeadCatModel;
        
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