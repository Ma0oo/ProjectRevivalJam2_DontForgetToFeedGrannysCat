using System;
using System.Collections.Generic;
using System.Linq;
using Plugins.MaoUtility.DILocator.Core;
using Plugins.MaoUtility.InputModule.Core.BaseClasses;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using Input = Plugins.MaoUtility.InputModule.Core.BaseClasses.Input;

namespace Plugins.MaoUtility.InputModule.Core
{
    public class InputManager : MonoBehaviour
    {
        [ShowInInspector, ReadOnly] private Dictionary<Type, HashSet<Input>> _inputs;

        public event Action<Input> Added;
        public event Action<Input> Removed;

        public void Init()
        {
            _inputs = new Dictionary<Type, HashSet<Input>>();
            GetComponentsInChildren<Input>().ForEach(x => Add(x));
        }

        public T Get<T>() where T : Input
        {
            if (_inputs.TryGetValue(typeof(T), out var r)) return r as T;
            var gm = new GameObject();
            gm.name = typeof(T).Name;
            var result = gm.AddComponent<T>();
            gm.transform.SetParent(transform);
            Add(result);
            result.InjectObj(DI.Instance);
            Added?.Invoke(result);
            return result;
        }
        
        public HashSet<T> GetAllClass<T>() where T : Input
        {
            HashSet<T> result = new HashSet<T>();
            var targetType = typeof(T);
            foreach (var inputPair in _inputs)
            {
                if (inputPair.Key.IsSubclassOf(typeof(T)) || inputPair.Key==typeof(T))
                {
                    inputPair.Value.ForEach(input =>
                    {
                        var r = input as T;
                        result.Add(r);
                    });
                }
            }
            return result;
        }
        
        public HashSet<T> GetAllInterface<T>() where T : class, IInput
        {
            HashSet<T> result = new HashSet<T>();
            var targetType = typeof(T);
            foreach (var inputPair in _inputs)
            {
                if (inputPair.Key.GetInterfaces().Contains(targetType))
                {
                    inputPair.Value.ForEach(input =>
                    {
                        var r = input as T;
                        result.Add(r);
                    });
                }
            }
            return result;
        }

        public void FastSubscribeActionByAllInputInstance<T>(Action<T> regCallback) where T : Input
            => GetAllClass<T>().ForEach(regCallback);
        
        public void FastSubscribeActionByAllInputInterface<T>(Action<T> regCallback) where T : class, IInput 
            => GetAllInterface<T>().ForEach(regCallback);

        private void Add(Input input)
        {
            if (_inputs.TryGetValue(input.GetType(), out var list))
                list.Add(input);
            else
                _inputs.Add(input.GetType(), new HashSet<Input>() {input});
        }
        
        private void Remove(Input input)
        {
            if (_inputs.TryGetValue(input.GetType(), out var list))
            {
                list.Remove(input);
                if (list.Count == 0) _inputs.Remove(input.GetType());
            }
        }

        public bool HasType(Input input) => _inputs.ContainsKey(input.GetType());
        
        public bool HasInstance(Input input)
        {
            if (HasType(input) == false) return false;
            return _inputs[input.GetType()].Contains(input);
        }

        public void Register(InputAutoRegister inputAutoRegister)
        {
            if(HasInstance(inputAutoRegister)) return;
            Add(inputAutoRegister);
            Added?.Invoke(inputAutoRegister);
        }

        public void Unregister(InputAutoRegister inputAutoRegister)
        {
            if(!HasInstance(inputAutoRegister)) return;
            Remove(inputAutoRegister);
            Removed?.Invoke(inputAutoRegister);
        }
    }
}