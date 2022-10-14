using System;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;
using UnityEngine;
using Input = UnityEngine.Input;

namespace Plugins.MaoUtility.TestModul.Ext
{
    public class InputOfTest : InputAutoRegister
    {
        [SerializeField] private KeyCode _keyForOpenClose = KeyCode.Tab;

        public event Action ChangeState;

        private void Update()
        {
            if(Input.GetKeyDown(_keyForOpenClose)) ChangeState?.Invoke();
        }
    }
}