using System;
using DataGame;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;
using UnityEngine;
using Input = UnityEngine.Input;

namespace DefaultNamespace.Player.Inventory.HandView
{
    [DiMark]
    public class HandInput : InputAutoRegister, IHandInput
    {
        public event Action<int> Select;
        public event Action DropSelected;

        [DiInject] private DataProvider _dataProvider;

        public void Update()
        {
            var keys = _dataProvider.DataSettingCurrent.Keys;
            if(Input.GetKeyDown(keys.FirstItem)) Select?.Invoke(0);
            if(Input.GetKeyDown(keys.SecondItem)) Select?.Invoke(1);
            if(Input.GetKeyDown(keys.ThirdItem)) Select?.Invoke(2);
            if(Input.GetKeyDown(keys.FourtedItem)) Select?.Invoke(3);
            if(Input.GetKeyDown(keys.FiftenItem)) Select?.Invoke(4);
            if(Input.GetKeyDown(keys.DropItem)) DropSelected?.Invoke();
        }
    }
}