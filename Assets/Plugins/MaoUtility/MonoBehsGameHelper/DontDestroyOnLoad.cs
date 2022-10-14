using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
#if HasAssets_ODIN

#endif

namespace Plugins.MaoUtility.MonoBehsGameHelper
{
    [AddComponentMenu("Mao Mono/Dont destroy on load")]
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private static Dictionary<string, DontDestroyOnLoad> _objects = new Dictionary<string, DontDestroyOnLoad>();
        #if HasAssets_ODIN
        [ReadOnly]
        #endif
        [SerializeField] private string _guid = Guid.NewGuid().ToString();
        
        private void Awake()
        {
            if (_objects.ContainsKey(_guid))
            {
                if (_objects[_guid] != null)
                {
                    Destroy(gameObject);
                    return;
                }
            }

            _objects.Remove(_guid);
            _objects.Add(_guid, this);
            DontDestroyOnLoad(gameObject);
        }

        #if HasAssets_ODIN
        [Button]
        #endif
        private void NewGuid() => _guid = Guid.NewGuid().ToString();
    }
}