using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.DILocator.Core.BaseClasses;
using Plugins.MaoUtility.TestModul.Core;
using UnityEngine;

namespace Plugins.MaoUtility.TestModul.Ext
{
    public class RegisterTestModule : RegisterDI
    {
        [SerializeField] private TestContextManager _context;
        
        protected override void Register(DI di) => di.Set(_context);

        protected override void Unregister(DI di) => di.Remove<TestContextManager>();
    }
}