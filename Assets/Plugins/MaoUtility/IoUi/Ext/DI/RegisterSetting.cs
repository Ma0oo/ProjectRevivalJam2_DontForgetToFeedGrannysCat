using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using Plugins.MaoUtility.IoUi.Core;
using UnityEngine;

namespace Plugins.MaoUtility.IoUi.Ext.DI
{
    public class RegisterSetting : RegisterDI
    {
        [SerializeField] private IoManager ioManager;

        protected override void Register(DILocator.Core.DI di) => di.Set(ioManager);

        protected override void Unregister(DILocator.Core.DI di) => di.Remove<IoManager>();
    }
}