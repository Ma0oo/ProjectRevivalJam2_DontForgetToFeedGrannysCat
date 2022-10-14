using System;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;

namespace ScenesLogic.Menu.Input
{
    public class MenuInputUI : InputAutoRegister, IMenuInput
    {
        public event Action StartGame;
        public event Action ToSetting;
        public event Action Credit;
        public event Action Exit;
        public event Action BakcByHistoryPanel;

        public void Play() => StartGame?.Invoke();
        public void OpenSetting() => ToSetting?.Invoke();
        public void OpenCredit() => Credit?.Invoke();
        public void ExitGame() => Exit?.Invoke();
        public void OpenLastPanel() => BakcByHistoryPanel?.Invoke();
    }
}