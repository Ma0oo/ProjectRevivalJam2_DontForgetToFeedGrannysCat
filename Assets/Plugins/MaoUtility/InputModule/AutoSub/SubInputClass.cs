using System;
using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.InputModule.Core;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;
using Plugins.MaoUtility.MaoExts.Static;

namespace Plugins.MaoUtility.InputModule.AutoSub
{
    public class SubInputClass<T> where T : Input
    {
        private Action<T> _reg;
        private Action<T> _unreg;
        private InputManager _inputManager;

        public SubInputClass(Action<T> register, Action<T> unregister)
        {
            _reg = register;
            _unreg = unregister;
            _inputManager = DI.Instance.Get<InputManager>();
        }
        
        public SubInputClass(Action<T> register, Action<T> unregister, InputManager inputManager)
        {
            _reg = register;
            _unreg = unregister;
            _inputManager = inputManager;
        }

        public void SubscribeAction(bool isSub)
        {
            if (isSub)
            {
                _inputManager.FastSubscribeActionByAllInputInstance<T>(_reg);
                _inputManager.Added += Sub;
                _inputManager.Removed += Unsub;
            }
            else
            {
                _inputManager.FastSubscribeActionByAllInputInstance<T>(_unreg);
                _inputManager.Added -= Sub;
                _inputManager.Removed -= Unsub;
            }
        }

        private void Sub(Input i) => (i as T)?.With(_reg);
        
        private void Unsub(Input i) => (i as T)?.With(_unreg);
    }
}