using System;
using System.Collections.Generic;
using System.Linq;
using DataGame.Save;
using DefaultNamespace.ApartmentSystem;
using DefaultNamespace.Player;
using NoSystem;
using Player.Controlls;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.MaoExts.Static;
using Plugins.MaoUtility.SceneFlow;
using Plugins.MaoUtility.SceneShareData;
using Plugins.MaoUtility.SM;
using ScenesLogic.Menu;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEditor.SearchService;
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
        [DiInject] private NightProvider _nightProvider;
        [DiInject] private SaveDataProvider _saveDataProvider;

        public NightControl NightControl => _nightControl ??= Owner.Get<NightControl>();
        private NightControl _nightControl;
        private GameResult _gameResult;
        private GameLoopData _data;
        private GameTime _gameTime;
        private PlayerUnit _player;

        private void Start()
        {
            _gameResult = Owner.Get<GameResult>();
            _data = SceneShareDataProvider.Instance.Get<GameLoopData>();
            _gameTime = Owner.Get<GameTime>();
            
            _gameTime.Init(_data.NightSO); 
            _apartmentFactory.Init(_data.NightSO.Apartment);
            _player = _playerFactory.GetOrCreate();
            NightControl.Init(_data.NightSO.Controller);
            
            _smGame.ChangeTo(StateGame.OnLoad);
            CoroutineGame.Instance.WaitFrame(3, Init);
        }

        private void Init()
        {
            _fadeScreenScene.Off();
            
            List<PlayerSpawnPoint> _points = new List<PlayerSpawnPoint>();
            _apartmentFactory.App.Rooms.ForEach(x => x.RoomParts.GetAll<PlayerSpawnPoint>().ForEach(x => _points.Add(x)));
            _points.GetRandom().Set(_player);

            _gameResult.Win += OnWin;
            _gameResult.Lose += OnLose;
            
            NightControl.OnInited();
            _smGame.ChangeTo(StateGame.Gameloop);
        }

        private void OnWin()
        {
            _saveDataProvider.Current.UpdateNight(_data.NightSO, _nightProvider.Nights.ToArray());
            _saveDataProvider.Save();
            
            _gameResult.Win -= OnWin;
            _gameResult.Lose -= OnLose;
            _smGame.ChangeTo(StateGame.Win);
            
            _player.Parts.Get<PlayerController>().enabled = false;
            _fadeScreenScene.On(()=>CoroutineGame.Instance.Wait(1, EnterToMenu));
        }

        private void OnLose()
        {
            _gameResult.Win -= OnWin;
            _gameResult.Lose -= OnLose;
            _smGame.ChangeTo(StateGame.Lose);
        }

        private void EnterToMenu()
        {
            SceneShareDataProvider.Instance.Remove(SceneShareDataProvider.Instance.Get<GameLoopData>());
            SceneLoader.Load(ConfigGame.Instance.MenuScene);
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