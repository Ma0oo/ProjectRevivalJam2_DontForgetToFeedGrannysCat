using System;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;

namespace ScenesLogic.Menu.Input
{
    public interface IMenuInput : IInput
    {
        event Action StartGame;
        event Action ToSetting;
        event Action Credit;
        event Action Exit;

        event Action BakcByHistoryPanel;
    }
}