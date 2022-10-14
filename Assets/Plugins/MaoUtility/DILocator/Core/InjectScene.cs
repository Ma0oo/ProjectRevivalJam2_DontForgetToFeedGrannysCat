using System.Linq;
using System.Reflection;
using Plugins.MaoUtility.DILocator.Atr;
using Sirenix.OdinInspector;
using UnityEngine;

#if HasAssets_ODIN

#endif

namespace Plugins.MaoUtility.DILocator.Core
{
    [AddComponentMenu("Mao Mono/Inject Scene")]
    public class InjectScene : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] _cacheMonoBeh;

        public void Inject()
        {
            foreach (var mono in _cacheMonoBeh) mono.InjectObj(DI.Instance);
        }

        #if HasAssets_ODIN
        [Button] 
        #endif
        [ContextMenu("Valid")]
        private void OnValidate()
        {
            _cacheMonoBeh = FindObjectsOfType<MonoBehaviour>(true).Where(x => CustomAttributeExtensions.GetCustomAttribute<DiMark>((MemberInfo) x.GetType()) != null).ToArray();
        }
    }
}