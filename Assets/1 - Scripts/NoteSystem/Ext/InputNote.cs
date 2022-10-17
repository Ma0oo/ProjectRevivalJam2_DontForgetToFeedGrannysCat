using System;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;
using UnityEngine;
using Input = UnityEngine.Input;

namespace DefaultNamespace.NoteSystem
{
    public class InputNote : InputAutoRegister
    {
        public event Action Close;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) Close?.Invoke();
        }
    }
}