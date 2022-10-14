using System;
using UnityEngine;

namespace Plugins.MaoUtility.MonoBehsGameHelper.LifeEvents
{
    public class EnableDisableEvent : MonoBehaviour
    {
        public event Action Enabled;
        public event Action Disabled;

        private void OnEnable() => Enabled?.Invoke();

        private void OnDisable() => Disabled?.Invoke();
    }
}