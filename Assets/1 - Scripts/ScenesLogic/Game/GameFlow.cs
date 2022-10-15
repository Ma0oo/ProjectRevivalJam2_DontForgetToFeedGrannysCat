using DefaultNamespace.Player;
using NoSystem;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.MaoExts.Static;
using Plugins.MaoUtility.SceneFlow;
using Plugins.MaoUtility.SM;
using ScenesLogic.Menu;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game
{
    [DiMark]
    public class GameFlow : SceneLogic
    {
        public IClosedSM<StateGame> Sm => _smGame;
        [SerializeField] private SM _smGame;

        [DiInject] private PlayerFactory _playerFactory;
        [DiInject(RegisterFadeScreenBetweenScene.FadeScreenBlack)] private FadeScreen _fadeScreenScene;

        private GameResult _gameResult;

        private void Start()
        {
            _smGame.ChangeTo(StateGame.OnLoad);
            CoroutineGame.Instance.WaitFrame(3, Init);
        }

        private void Init()
        {
            _gameResult = Owner.Get<GameResult>();
            var player = _playerFactory.GetOrCreate();
            _fadeScreenScene.Off();
            _smGame.ChangeTo(StateGame.Gameloop);
        }

        public enum StateGame
        {
            OnLoad, Gameloop, Win, Lose
        }
        
        [System.Serializable]
        public class SM : SmByStruct<StateGame>
        {
            
        }
    }
}