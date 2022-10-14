using System;
using Plugins.MaoUtility.IoUi.Core;

namespace DataGame.Sound
{
    public class ConnectSoundIniter : ConnectorTypeForManager
    {
        public override Type TargetTypeHandler => typeof(IoSoundHandler);
        public override Type GetTypeIniter() => typeof(IoSoundIniter);
    }
}