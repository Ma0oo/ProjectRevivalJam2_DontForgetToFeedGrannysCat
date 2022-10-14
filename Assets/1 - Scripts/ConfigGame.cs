using DataGame;
using Plugins.MaoUtility.MonoBehsGameHelper;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Configs/Game", order = 51)]
    public class ConfigGame : ConfigSo<ConfigGame>
    {
        public DataSetting DefaultSetting;
        public string GameScene;
        public string MenuScene;
    }
}