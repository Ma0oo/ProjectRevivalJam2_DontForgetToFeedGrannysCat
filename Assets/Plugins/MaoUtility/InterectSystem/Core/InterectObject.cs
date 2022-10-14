using System;
using Plugins.MaoUtility.InterectSystem.Core.BasesClasses;
using UnityEngine;

namespace Plugins.MaoUtility.InterectSystem.Core
{
    public class InterectObject : MonoBehaviour
    {
        public event Action<InterectActionBase> Interected;

        public InterectObject Interect(InterectActionBase actionBase)
        {
            Interected?.Invoke(actionBase);
            return this;
        }
    }
}