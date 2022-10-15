using System;
using System.Collections.Generic;
using DefaultNamespace.ApartmentSystem;
using DefaultNamespace.Player;
using NoSystem;
using Plugins.MaoUtility.DataBetweenScene;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.MaoExts.Static;
using Plugins.MaoUtility.SceneFlow;
using Plugins.MaoUtility.SM;
using ScenesLogic.Menu;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
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
        [DiInject] private ApartmentFactory _apartmentFactory;

        private GameResult _gameResult;
        private GameLoopData _data;

        private void Start()
        {
            _data = SceneShareDataProvider.Instance.Get<GameLoopData>();
            _apartmentFactory.Init(_data.NightSO.Apartment);
            _smGame.ChangeTo(StateGame.OnLoad);
            CoroutineGame.Instance.WaitFrame(3, Init);
        }

        private void Init()
        {
            _gameResult = Owner.Get<GameResult>();
            var player = _playerFactory.GetOrCreate();
            _fadeScreenScene.Off();
            
            List<PlayerSpawnPoint> _points = new List<PlayerSpawnPoint>();
            _apartmentFactory.App.Rooms.ForEach(x => x.RoomParts.GetAll<PlayerSpawnPoint>().ForEach(x => _points.Add(x)));
            _points.GetRandom().Set(player);
            
            _smGame.ChangeTo(StateGame.Gameloop);
        }

        private void OnDestroy()
        {
            SceneShareDataProvider.Instance.Remove(SceneShareDataProvider.Instance.Get<GameLoopData>());
            
        }

        public enum StateGame
        {
            OnLoad, Gameloop, Win, Lose
        }

        [System.Serializable]
        public class SM : SmByStruct<StateGame>
        {
            
        }
        
        [System.Serializable]
        public class GameLoopData : IShereSceneData
        {
            public Night NightSO { get; private set; }

            public GameLoopData(Night night)
            {
                NightSO = night;
            }

            public object Clone() => new GameLoopData(NightSO);
        }
    }
}