using Plugins.MaoUtility.DILocator.Core;
using UnityEngine;

namespace Plugins.MaoUtility.IoUi.Core
{
    public abstract class IoGroupHandler : MonoBehaviour
    {
        protected IoManager IoManager => _ioManager??=DI.Instance.Get<IoManager>();
        private IoManager _ioManager;
        
        protected virtual void Register<T>() where T : IoGroupHandler => IoManager.Get<T>().Register(this as T);

        protected virtual void Unregister<T>() where T : IoGroupHandler => IoManager.Get<T>()?.Unregister(this as T);
    }
}