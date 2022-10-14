using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;

namespace Plugins.MaoUtility.InterectSystem.Implementation.RayView
{
    public class RayAction : InterectActionBase
    {
        public bool State { get; private set; }
        
        public RayAction(bool state) => State = state;
    }
}