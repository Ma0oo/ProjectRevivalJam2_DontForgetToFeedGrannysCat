using System;
using System.ComponentModel;
using Plugins.MaoUtility.SceneFlow;
using Unity.VisualScripting;

namespace DefaultNamespace.ScenesLogic.Game
{
    public class GameResult : SceneLogic
    {
        public event Action Win;
        public event Action Lose;

        private void Start()
        {
            Owner.Get<GameTime>().AllHourPass += () => Win?.Invoke();
        }
    }
}
