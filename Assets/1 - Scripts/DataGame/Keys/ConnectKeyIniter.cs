using System;
using Plugins.MaoUtility.IoUi.Core;

namespace DataGame.Keys
{
    public class ConnectKeyIniter : ConnectorTypeForManager
    {
        public override Type TargetTypeHandler => typeof(IoKeyHandler);
        public override Type GetTypeIniter() => typeof(IoKeyIniter);
    }
}