using System;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.DILocator.Core;

namespace Plugins.MaoUtility.InputModule.Core.BaseClasses
{
    [DiMark]
    public abstract class InputAutoRegister : Input
    {
        private InputManager InputManager => _inputManager ??= DI.Instance.Get<InputManager>();
        private InputManager _inputManager;

        protected virtual void Start() => InputManager.Register(this);

        protected virtual  void OnDestroy()
        {
            try
            {
                InputManager.Unregister(this);
            }
            catch (Exception e)
            {
            }
        }
    }
}