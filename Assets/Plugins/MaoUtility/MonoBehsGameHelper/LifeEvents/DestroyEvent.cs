using System;
using UnityEngine;

namespace Plugins.MaoUtility.MonoBehsGameHelper.LifeEvents
{
    public class DestroyEvent : MonoBehaviour
    {
        public event Action Destroyed;
        public event Action<GameObject> DestroyedGO;

        private void OnDestroy()
        {
            Destroyed?.Invoke();
            DestroyedGO?.Invoke(gameObject);
        }
    }
}