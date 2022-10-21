using System;
using DataGame;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game.Input
{
    [DiMark]
    public class KeyGameInput : InputAutoRegister, IGameInput
    {
        public event Action MenuGame;
        
        [DiInject] private DataProvider _dataProvider;

        private void Update()
        {
            if(UnityEngine.Input.GetKeyDown(_dataProvider.DataSettingCurrent.Keys.MenuGame)) MenuGame?.Invoke();
        }
    }
}