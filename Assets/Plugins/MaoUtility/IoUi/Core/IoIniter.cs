using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Plugins.MaoUtility.IoUi.Core
{
    public abstract class IoIniter<T> : MonoBehaviour where T : IoGroupHandler
    {
        [ShowInInspector, ReadOnly] protected HashSet<T> Panels = new HashSet<T>();

        public virtual void Register(T panel)
        {
            Panels.Add(panel);
        }

        public virtual void Unregister(T panel)
        {
            Panels.Remove(panel);
        }
    }
}