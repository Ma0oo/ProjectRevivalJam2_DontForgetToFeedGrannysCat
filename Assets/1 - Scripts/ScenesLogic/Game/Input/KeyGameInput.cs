using System;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game.Input
{
    public class KeyGameInput : InputAutoRegister, IGameInput
    {
        public event Action MenuGame;

        private void Update()
        {
            if(UnityEngine.Input.GetKeyDown(KeyCode.Escape)) MenuGame?.Invoke();
        }
    }
}