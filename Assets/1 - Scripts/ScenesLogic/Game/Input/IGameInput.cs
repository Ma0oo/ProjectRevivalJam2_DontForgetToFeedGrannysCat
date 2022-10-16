using System;
using DefaultNamespace.ScenesLogic.Game.GameLose;
using NoSystem;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;
using Plugins.MaoUtility.SM;

namespace DefaultNamespace.ScenesLogic.Game.Input
{
    public interface IGameInput : IInput
    {
        public event Action MenuGame;
    }
}