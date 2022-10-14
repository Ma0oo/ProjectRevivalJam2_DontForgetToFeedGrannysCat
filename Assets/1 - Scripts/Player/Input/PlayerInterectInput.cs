using System;
using UnityEngine;

namespace Player.Input
{
    public class PlayerInterectInput : Plugins.MaoUtility.InputModule.Core.BaseClasses.Input
    {
        public event Action Interect;

        private void Update()
        {
            if(UnityEngine.Input.GetKeyDown(KeyCode.F)) Interect?.Invoke();
        }
    }
}