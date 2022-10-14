using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using Plugins.MaoUtility.InputModule.Core;
using UnityEngine;

namespace Plugins.MaoUtility.InputModule.Ext.DI
{
    public class RegisterInputManager : RegisterDI
    {
        [SerializeField] private InputManager _inputManager;
        
        protected override void Register(DILocator.Core.DI di)
        {
            _inputManager.Init();
            di.Set(_inputManager);
        }

        protected override void Unregister(DILocator.Core.DI di) => di.Remove<InputManager>();
    }
}