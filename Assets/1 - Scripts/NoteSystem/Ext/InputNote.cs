using System;
using DataGame;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;
using UnityEngine;
using Input = UnityEngine.Input;

namespace DefaultNamespace.NoteSystem
{
    [DiMark]
    public class InputNote : InputAutoRegister
    {
        public event Action Close;
        
        [DiInject] private DataProvider _dataProvider;

        private void Update()
        {
            if (Input.GetKeyDown(_dataProvider.DataSettingCurrent.Keys.CloseNote)) Close?.Invoke();
        }
    }
}