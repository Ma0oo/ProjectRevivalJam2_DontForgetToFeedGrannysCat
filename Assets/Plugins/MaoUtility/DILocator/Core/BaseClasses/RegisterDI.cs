using UnityEngine;

namespace Plugins.MaoUtility.DILocator.Core.BaseClasses
{
    public abstract class RegisterDI : MonoBehaviour
    {
        public void Register() => Register(DI.Instance);

        public void Unregister() => Unregister(DI.Instance);

        protected abstract void Register(DI di);
        protected abstract void Unregister(DI di);
    }
}