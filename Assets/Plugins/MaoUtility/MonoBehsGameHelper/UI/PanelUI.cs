using System.Collections.Generic;
using Lean.Transition;
using Sirenix.OdinInspector;
using UltEvents;
using UnityEngine;

#if HasAssets_LeanTransition
#endif

#if HasAssets_ODIN
#endif

#if HasAssets_UltEvents
#endif

namespace Plugins.MaoUtility.MonoBehsGameHelper.UI
{
#if HasAssets_ODIN
    [AddComponentMenu("Mao Mono/Panel UI")]
    public class PanelUI : SerializedMonoBehaviour
#else
    [AddComponentMenu("Mao Mono/Panel UI")]
    public class PanelUI : MonoBehaviour
#endif
    {
        public bool IsOn => _isOn;
        [SerializeField] private bool _isOn;
        [SerializeField] private bool _updateOnStart;
        
        [SerializeField] private GroupAction _on;
        [SerializeField] private GroupAction _off;
        [SerializeField] private Dictionary<string, GroupAction> _customActions=new Dictionary<string, GroupAction>();

        private void Start()
        {
            if(_updateOnStart) MakeDefaultAction();
        }

        #if HasAssets_ODIN
        [Button]
        #endif
        public void SetActive(bool isActive)
        {
            _isOn = isActive;
            MakeDefaultAction();
        }

        public void Invert()
        {
            _isOn = !_isOn;
            MakeDefaultAction();
        }
        
        public void SetSafeActive(bool isActive)
        {
            if(_isOn==isActive) return;
            _isOn = isActive;
            MakeDefaultAction();
        }

        #if HasAssets_ODIN
        [Button]
        #endif
        public void TryCustomAction(string name)
        {
            if(_customActions.TryGetValue(name, out var r)) r.Activated();
        }
        
        private void MakeDefaultAction()
        {
            if(_isOn) _on.Activated();
            else _off.Activated();
        }

        [System.Serializable]
        public class GroupAction
        {
            
            #if HasAssets_LeanTransition
            public LeanPlayer LeanAnim;
            #endif
            #if HasAssets_UltEvents
            public UltEvent Event;
            #endif
            

            public void Activated()
            {
                #if HasAssets_UltEvents
                Event.Invoke();
                #endif
                #if HasAssets_LeanTransition
                LeanAnim.Begin();
                #endif
            }
        }
    }
}
