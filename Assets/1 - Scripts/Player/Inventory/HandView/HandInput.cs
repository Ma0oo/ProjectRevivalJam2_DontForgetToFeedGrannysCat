using System;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;
using UnityEngine;
using Input = UnityEngine.Input;

namespace DefaultNamespace.Player.Inventory.HandView
{
    public class HandInput : InputAutoRegister, IHandInput
    {
        public event Action<int> Select;
        public event Action DropSelected;

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1)) Select?.Invoke(0);
            if(Input.GetKeyDown(KeyCode.Alpha2)) Select?.Invoke(1);
            if(Input.GetKeyDown(KeyCode.Alpha3)) Select?.Invoke(2);
            if(Input.GetKeyDown(KeyCode.Alpha4)) Select?.Invoke(3);
            if(Input.GetKeyDown(KeyCode.Alpha5)) Select?.Invoke(4);
            if(Input.GetKeyDown(KeyCode.G)) DropSelected?.Invoke();
        }
    }
}