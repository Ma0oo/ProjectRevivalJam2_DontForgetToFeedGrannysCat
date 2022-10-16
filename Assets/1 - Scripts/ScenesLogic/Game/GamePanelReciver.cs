using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.SceneFlow;
using UltEvents;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game.Input
{
    [DiMark]
    public class GamePanelReciver : MonoBehaviour
    {
        [DiInject] private OwnerSceneLogic _ownerSceneLogic;

        public UltEvent<bool> NewStateMenuPanel;

        private void Start()
        {
            var panel = _ownerSceneLogic.Get<GamePanel>();
            if(!panel) return;
            panel.NewStateMenuPanel += OnNewStateMenuPanel;
        }

        private void OnNewStateMenuPanel(bool obj) => NewStateMenuPanel.Invoke(!obj);
    }
}