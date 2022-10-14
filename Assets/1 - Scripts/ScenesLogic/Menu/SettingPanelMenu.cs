using System;
using System.Linq;
using DataGame;
using DataGame.Keys;
using DataGame.Sound;
using NoSystem;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.InputModule.AutoSub;
using Plugins.MaoUtility.InputModule.Core;
using Plugins.MaoUtility.MaoExts.Static;
using Plugins.MaoUtility.SceneFlow;
using ScenesLogic.Menu.Input;
using Sirenix.Utilities;
using UnityEngine;

namespace ScenesLogic.Menu
{
    [DiMark]
    public class SettingPanelMenu : SceneLogic
    {
        [SerializeField] private IoSoundHandler _ioSoundHandlers;
        [SerializeField] private IoKeyHandler _keyHandler;

        private PanelMenu _panelMenu;

        [DiInject] private DataProvider _settingsProvider;

        [DiInject(RegisterFadeScreenBetweenScene.FadeScreenBlack)] private FadeScreen _fadeScreen;
        
        private IHideOpenIoBtn[] _handlers => new IHideOpenIoBtn[]{_ioSoundHandlers, _keyHandler};

        private SubInputInterface<IMenuInput> _sub;

        private void Start()
        {
            _ioSoundHandlers.On();
            _keyHandler.Off();
            _panelMenu = Owner.Get<PanelMenu>();
            _panelMenu.ChangeStateFrom += OnCloseMe;
            
            _sub = new SubInputInterface<IMenuInput>(Reg, Unreg);
            _sub.SubscribeAction(true);
        }

        private void OnCloseMe(PanelMenu.State obj)
        {
            if(obj!=PanelMenu.State.Setting) return;
            _settingsProvider.Save();
        }

        private void Reg(IMenuInput obj)
        {
            obj.OpenKeySetting += () => Open(_keyHandler);
            obj.OpenSoundSetting += () => Open(_ioSoundHandlers);
            obj.ClearProgress += () =>
            {
                _fadeScreen.On(() =>
                {
                    PlayerPrefs.DeleteAll();
                    SceneLoader.Restart(()=>_fadeScreen.Off());    
                });
            };
        }

        private void Open(IHideOpenIoBtn handler)
        {
            _handlers.Except(new[] {handler}).ForEach(x => x.Off());
            handler.On();
        }

        private void Unreg(IMenuInput obj)
        {
            
        }
    }
}