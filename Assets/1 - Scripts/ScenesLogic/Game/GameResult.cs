using System;
using Plugins.MaoUtility.SceneFlow;

namespace DefaultNamespace.ScenesLogic.Game
{
    public class GameResult : SceneLogic
    {
        public event Action Win;
        public event Action Lose;
    }
}