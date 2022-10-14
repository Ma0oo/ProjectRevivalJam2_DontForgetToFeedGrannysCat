using System;

namespace Plugins.MaoUtility.IoUi.Core
{
    public abstract class ConnectorTypeForManager
    {
        public abstract Type TargetTypeHandler { get; }
        public abstract Type GetTypeIniter();
    }
}