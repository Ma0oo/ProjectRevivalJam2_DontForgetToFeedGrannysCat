using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.SceneFlow;
using UltEvents;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game
{
    [DiMark] 
    public class GameFlowReciver : MonoBehaviour
    {
        [DiInject] private OwnerSceneLogic _ownerSceneLogic;

        public UltEvent<GameFlow.StateGame> EnterTo;
        public UltEvent<GameFlow.StateGame> ExitFrom;

        private void Start()
        {
            var flow = _ownerSceneLogic.Get<GameFlow>();
            flow.Sm.EnterTo += x => EnterTo?.Invoke(x);
            flow.Sm.ExitFrom += x => ExitFrom?.Invoke(x);
            EnterTo?.Invoke(flow.Sm.Current);
        }
    }
}