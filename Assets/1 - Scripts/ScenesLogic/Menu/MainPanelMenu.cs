using System;
using DefaultNamespace;
using NoSystem;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.InputModule.AutoSub;
using Plugins.MaoUtility.InputModule.Core;
using Plugins.MaoUtility.MaoExts.Static;
using Plugins.MaoUtility.SceneFlow;
using ScenesLogic.Menu.Input;
using Unity.VisualScripting;
using UnityEngine;

namespace ScenesLogic.Menu
{
    [DiMark]
    public class MainPanelMenu : SceneLogic
    {
        [DiInject(RegisterFadeScreenBetweenScene.FadeScreenBlack)] private FadeScreen _fadeScreen;
        [DiInject] private InputManager _inputManager;

        [SerializeField] private float _delayFirstFadeScreen;

        private PanelMenu Panels=>_panels??=Owner.Get<PanelMenu>();
        private PanelMenu _panels;

        private static bool _isFirstEnter=true;

        public event Action FadeOnStartOff;
        public event Action GameStarted;

        private SubInputInterface<IMenuInput> _menuInput;

        private void Start()
        {
            _menuInput = new SubInputInterface<IMenuInput>(Reg, Unreg, _inputManager);
            _menuInput.SubscribeAction(true);
            
            if (_isFirstEnter)
            {
                _fadeScreen.SetInstanceState(true);
                CoroutineGame.Instance.Wait(_delayFirstFadeScreen, ()=>
                {
                    _fadeScreen.Off();
                    FadeOnStartOff?.Invoke();
                });
                _isFirstEnter = false;
            }
            else
            {
                FadeOnStartOff?.Invoke();
            }
        }

        private void Reg(IMenuInput obj)
        {
            obj.StartGame += StartGame;
            obj.Credit += OnCredit;
            obj.Exit += OnExit;
            obj.ToSetting += ToSetting;
        }

        private void Unreg(IMenuInput obj)
        {
            obj.StartGame -= StartGame;
            obj.Credit -= OnCredit;
            obj.Exit -= OnExit;
            obj.ToSetting -= ToSetting;
        }

        private void OnExit() => _fadeScreen.Transition(()=>Application.Quit());

        private void StartGame()
        {
            GameStarted?.Invoke();
            _fadeScreen.On(() => SceneLoader.Load(ConfigGame.Instance.GameScene));
            
        }

        private void OnCredit() => Panels.ChangeState(PanelMenu.State.Credit);

        private void ToSetting() => Panels.ChangeState(PanelMenu.State.Setting);
    }
}