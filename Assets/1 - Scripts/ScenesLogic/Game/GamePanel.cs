using System;
using NoSystem;
using Plugins.MaoUtility.InputModule.AutoSub;
using Plugins.MaoUtility.MonoBehsGameHelper.UI;
using Plugins.MaoUtility.SceneFlow;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game.Input
{
    public class GamePanel : SceneLogic
    {
        [SerializeField] private PanelUI _win;
        [SerializeField] private PanelUI _lose;
        [SerializeField] private PanelUI _menu;
        
        private GameFlow GameFlow => Owner.Get<GameFlow>();
        
        private SubInputInterface<IGameInput> _sub;

        public event Action<bool> NewStateMenuPanel;

        private void Start()
        {
            _sub=new SubInputInterface<IGameInput>(x=>x.MenuGame+=OnMenuGame, x=>x.MenuGame-=OnMenuGame);
            _sub.SubscribeAction(true);
            GameFlow.Sm.EnterTo += OnWinLose;
        }

        private void OnWinLose(GameFlow.StateGame obj)
        {
            if (obj == GameFlow.StateGame.Win || obj == GameFlow.StateGame.Lose)
            {
                _sub.SubscribeAction(false);
                if (_menu.IsOn != false)
                {
                    _menu.SetSafeActive(false);
                    NewStateMenuPanel?.Invoke(false);
                }
            }
            if (obj == GameFlow.StateGame.Win) _win.SetActive(true);
            if(obj == GameFlow.StateGame.Lose) _lose.SetActive(true);
        }

        private void OnMenuGame()
        {
            if(GameFlow.Sm.Current!=GameFlow.StateGame.Gameloop) return;
            _menu.Invert();
            NewStateMenuPanel?.Invoke(_menu.IsOn);
        }
    }
}