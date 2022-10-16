using System;
using System.Collections.Generic;
using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.IoUi.Static;
using UnityEngine;

namespace Plugins.MaoUtility.IoUi.Core
{
    public class IoManager : MonoBehaviour
    {
        private Dictionary<Type, object> _controls = new Dictionary<Type, object>();

        public IoIniter<T> Get<T>() where T : IoGroupHandler
        {
            if(_controls.TryGetValue(typeof(T), out var r))
                return r as IoIniter<T>;

            var component = gameObject.AddComponent(SettingControlManagerOfTPanel.GetTypeByTPanel<T>()) as IoIniter<T>;
            _controls.Add(typeof(T), component);
            component.InjectObj(DI.Instance);
            return component;
        }
    }
}