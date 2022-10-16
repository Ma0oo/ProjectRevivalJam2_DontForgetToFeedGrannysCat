using System;
using System.Collections.Generic;
using System.ComponentModel;
using DefaultNamespace.ScenesLogic.Game.GameLose;
using Plugins.MaoUtility.SceneFlow;
using Sirenix.OdinInspector;
using Unity.VisualScripting;

namespace DefaultNamespace.ScenesLogic.Game
{
    public class GameResult : SceneLogic
    {
        public event Action Win;
        public event Action Lose;

        private HashSet<IGameLose> _loses = new HashSet<IGameLose>();

        private void Start()
        {
            Owner.Get<GameTime>().AllHourPass += OnWin;
        }

        public void Register(IGameLose loseGameComponent)
        {
            if(_loses.Contains(loseGameComponent)) return;
            _loses.Add(loseGameComponent);
            loseGameComponent.InLose += OnLose;
        }

        [Button]private void OnLose() => Lose?.Invoke();
        
        [Button]private void OnWin() => Win?.Invoke();

        public void UnRegister(IGameLose loseGameComponent)
        {
            if(_loses.Remove(loseGameComponent))
                loseGameComponent.InLose -= OnLose;
        }
    }
}
