using System;
using Plugins.MaoUtility.AdvanceEvents.EventSlowpoke;
using Plugins.MaoUtility.AdvanceEvents.EventSlowpoke.Implementation;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.MaoExts.Static;
using UnityEngine;

namespace DefaultNamespace.Player.View
{
    [DiMark]
    public class ViewPlayerReciver : MonoBehaviour
    {
        [DiInject] private PlayerFactory _playerFactory;

        public EventSlowpoke<PlayerUnit> Inited = new EventSlowpoke<PlayerUnit>();

        private void Start() => CoroutineGame.Instance.WaitFrame(5, Init);

        private void Init() => Inited?.Post(_playerFactory.GetOrCreate());
    }
}