using UnityEngine;

namespace Plugins.MaoUtility.MonoBehsGameHelper.UI
{
    public class ControlPanelInGame : MonoBehaviour
    {
        private PanelUI _lastPanel;
        
        public void CloseAndRemember(PanelUI panelToClose)
        {
            _lastPanel = panelToClose;
            panelToClose.SetSafeActive(false);
        }

        public void Open(PanelUI panel) => panel.SetSafeActive(true);

        public void CloseAndOpenLast(PanelUI panelToClose)
        {
            if(!_lastPanel) Debug.LogWarning("ControlPanelInGame не имеет прошлой панели, она не будет открыта", gameObject);
            panelToClose.SetSafeActive(false);
            _lastPanel?.SetSafeActive(true);
        }
    }
}