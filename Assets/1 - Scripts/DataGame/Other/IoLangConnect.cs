using System;
using Plugins.MaoUtility.IoUi.Core;

namespace DataGame.Other
{
    public class IoLangConnect : ConnectorTypeForManager
    {
        public override Type TargetTypeHandler => typeof(IoLangHandler);
        public override Type GetTypeIniter() => typeof(IoLandIniter);
    }
}