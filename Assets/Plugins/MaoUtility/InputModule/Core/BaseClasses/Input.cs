using UnityEngine;

namespace Plugins.MaoUtility.InputModule.Core.BaseClasses
{
    public abstract class Input : MonoBehaviour
    {
        public bool IsTypeOrSub<T>() => this is T;
    }
}