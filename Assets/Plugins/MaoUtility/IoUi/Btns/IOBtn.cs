using System;
using Plugins.MaoUtility.IoUi.Btns.Components;
using UnityEngine;

namespace Plugins.MaoUtility.IoUi.Btns
{
    [RequireComponent(typeof(ComponentManagerIoBtn))]
    public abstract class IOBtn<T> : MonoBehaviour
    {
        public ComponentManagerIoBtn Components => _component??=GetComponent<ComponentManagerIoBtn>();
        [SerializeField] private ComponentManagerIoBtn _component;
        
        public abstract event Action<T, IOBtn<T>> Updated;
        public abstract void SetWithoutEvent(T value);

        public void UpdateStateBtn(T state, IOBtn<T> invoker)
        {
            if(invoker!=this) SetWithoutEvent(state);
        }
        public abstract void Init(Func<T> get, Action<T> set);
    }
}